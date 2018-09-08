using Quartz;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var vv = this._IStoreServerService.GetStoresDetails();
            //_heartbeat.UpdateServiceState("alive");
            return Task.CompletedTask;
        }
    }
}
