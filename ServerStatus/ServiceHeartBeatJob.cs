using Common.Logging;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Quartz;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerStatus
{
    class ServiceHeartBeatJob : IJob
    {

        private readonly IHeartbeatService _hearbeat;
        IStoreServerService _IStoreServerService;

        private static readonly ILog s_log = LogManager.GetLogger<HeartbeatJob>();

        public ServiceHeartBeatJob(IHeartbeatService hearbeat, IStoreServerService iStoreServerService)
        {
            if (hearbeat == null) throw new ArgumentNullException(nameof(hearbeat));
            _hearbeat = hearbeat;
            this._IStoreServerService = iStoreServerService;
        }

        public void Execute(IJobExecutionContext context)
        {

            if (!ServiceGlobalVariable.SignalRHubExists)
            {

                string url = "http://localhost:8080";
                using (WebApp.Start(url))
                {
                    Console.WriteLine("Server running on {0}", url);
                    ServiceGlobalVariable.SignalRHubExists = true;
                    Console.ReadLine();
                }

            }
            else
            {
                // Get the context for the Pusher hub
                IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                hubContext.Clients.All.addMessage("HeartBeat", DateTime.Now.ToString());
            }

         
        }

    }
}
