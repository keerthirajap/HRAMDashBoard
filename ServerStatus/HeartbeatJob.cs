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



    public class HeartbeatJob : IJob
    {


        private readonly IHeartbeatService _hearbeat;
        IStoreServerService _IStoreServerService;

        private static readonly ILog s_log = LogManager.GetLogger<HeartbeatJob>();

        public HeartbeatJob(IHeartbeatService hearbeat, IStoreServerService iStoreServerService)
        {
            if (hearbeat == null) throw new ArgumentNullException(nameof(hearbeat));
            _hearbeat = hearbeat;
            this._IStoreServerService = iStoreServerService;
        }



        public void Execute(IJobExecutionContext context)
        {



            if (ServiceGlobalVariable.SignalRHubExists)
            {

                // Get the context for the Pusher hub
                IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                hubContext.Clients.All.addMessage("StatusCheck", DateTime.Now.ToString());

            }
          


            List<StoreModel> storeList = new List<StoreModel>();
            storeList = this._IStoreServerService.GetStoresDetails();

            List<StoreServerModel> storeServerList = new List<StoreServerModel>();

            List<StoreServerModel> storeServerStatusList = new List<StoreServerModel>();

            storeServerList = this._IStoreServerService.GetStoresServerDetails();

            StoreServerModel storeServerDetails = new StoreServerModel();
            storeServerDetails.UserId = 1;
            Int64 batchId = this._IStoreServerService.GenerateServerServiceStatusBatch(storeServerDetails);

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