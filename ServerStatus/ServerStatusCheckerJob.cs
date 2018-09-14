namespace ServerStatus
{
    using System;

    using Common.Logging;
    using Quartz;
    using ServiceInterface;
    using System.Collections.Generic;
    using DomainModel;
    using System.Net.NetworkInformation;
    using Microsoft.AspNet.SignalR;
    using Microsoft.Owin.Hosting;
    using System.Threading;
    using System.Net;
    using System.IO;
    using Owin;
    using Microsoft.Owin.Cors;
    using System.Management;
    using System.Linq;
    public class ServerStatusCheckerJob : IJob
    {


        private readonly IHeartbeatService _hearbeat;
        IStoreServerService _IStoreServerService;

        private static readonly ILog s_log = LogManager.GetLogger<ServerStatusCheckerJob>();

        public ServerStatusCheckerJob(IHeartbeatService hearbeat, IStoreServerService iStoreServerService)
        {
            if (hearbeat == null) throw new ArgumentNullException(nameof(hearbeat));
            _hearbeat = hearbeat;
            this._IStoreServerService = iStoreServerService;
        }



        public void Execute(IJobExecutionContext context)
        {

            List<StoreModel> storeList = new List<StoreModel>();
            storeList = this._IStoreServerService.GetStoresDetails();

            List<StoreServerModel> storeServerList = new List<StoreServerModel>();

            List<StoreServerModel> storeServerStatusList = new List<StoreServerModel>();

            List<ServerServiceStatus> windowsServiceList = new List<ServerServiceStatus>();
            List<ServerServiceStatus> windowsServiceRunList = new List<ServerServiceStatus>();


            storeServerList = this._IStoreServerService.GetStoresServerDetails();
            windowsServiceList = this._IStoreServerService.GetWindowsServiceDetails();

            StoreServerModel storeServerDetails = new StoreServerModel();
            storeServerDetails.UserId = 1;

            Int64 batchId = this._IStoreServerService.GenerateServerServiceStatusBatch(storeServerDetails);

            Int64 windowsBatchId = this._IStoreServerService.GenerateWindowsServiceStatusBatch(storeServerDetails);
            foreach (var item in storeServerList)
            {

                StoreServerModel storeServerStatus = new StoreServerModel();
                storeServerStatus = item;
                storeServerStatus.ServerStatusBatchId = batchId;
                try
                {
                    Ping myPing = new Ping();
                    PingReply reply = myPing.Send(item.ISSIpAddress, 1000);

                    if (reply != null)
                    {
                        if (reply.Status == IPStatus.Success)
                        {
                            storeServerStatus.IsServerActive = true;
                            storeServerStatus.ServerResponseTime = Convert.ToInt32(reply.RoundtripTime);

                        }
                        else
                        {
                            storeServerStatus.IsServerActive = false;
                        }

                    }
                }
                catch (Exception)
                {

                    storeServerStatus.IsServerActive = false;

                }

                List<ServerServiceStatus> windowsServiceCurrentRunList = new List<ServerServiceStatus>();

                windowsServiceCurrentRunList = windowsServiceList.Where(
                                                     w => w.StoreNo == item.StoreNo
                                                                        ).ToList();

                if (storeServerStatus.IsServerActive == true
                    && windowsServiceCurrentRunList != null
                    && windowsServiceCurrentRunList.Count > 0
                    )
                {
                    try
                    {
                        ConnectionOptions op = new ConnectionOptions();
                        op.Username = "Keerthi Raja P";
                        op.Password = "KIRTHI789+K";
                        ManagementScope scope = new ManagementScope(@"\\" +
                                                            item.ISSIpAddress
                                                            + @"\root\cimv2", null);
                        scope.Connect();
                        ManagementPath path = new ManagementPath("Win32_Service");
                        ManagementClass services;
                        services = new ManagementClass(scope, path, null);

                        ManagementObjectCollection moc = services.GetInstances();
                        ManagementObject[] deviceArray = new ManagementObject[moc.Count];
                        moc.CopyTo(deviceArray, 0);

                        windowsServiceCurrentRunList.ForEach(x =>
                       {
                           ServerServiceStatus serverServiceStatus = new ServerServiceStatus();
                           serverServiceStatus = x;
                           var vvv = deviceArray.Where(w => w.GetPropertyValue("Name").ToString() == x.ServiceName);

                           if (vvv.Any(a => a.GetPropertyValue("State").ToString().ToLower().Equals("running"))
                           )
                           {
                               serverServiceStatus.IsServiceActive = true;
                           }
                           else
                           {
                               serverServiceStatus.IsServiceActive = false;

                           }

                       }
                            );

                        windowsServiceRunList.AddRange(windowsServiceCurrentRunList);
                    }
                    catch (Exception ex)
                    {

                        throw;
                    }
                }

                lock (storeServerStatusList)
                {
                    storeServerStatusList.Add(storeServerStatus);
                 
                }
            }



            //_heartbeat.UpdateServiceState("alive");
            var isUpdateSuccess = this._IStoreServerService.UpdateServerServiceStatusBatch(storeServerStatusList);

        }
    }
}