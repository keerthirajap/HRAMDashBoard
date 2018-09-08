using DomainModel;
using Quartz;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ServerStatusChecker
{
    public class HeartbeatJob : IJob
    {

        IStoreServerService _IStoreServerService;
        public HeartbeatJob(IStoreServerService iStoreServerService)
        {

            this._IStoreServerService = iStoreServerService;
        }

        public Task Execute(IJobExecutionContext context)
        {
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
            return Task.CompletedTask;
        }
    }
}
