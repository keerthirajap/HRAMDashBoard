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

            List<WindowsServiceStatus> windowsServiceList = new List<WindowsServiceStatus>();
            List<WindowsServiceStatus> windowsServiceRunList = new List<WindowsServiceStatus>();


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

                if (storeServerStatus.IsServerActive == true)
                {
                    try
                    {

                    }
                    catch (Exception)
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