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
using DomainModel;
namespace ServerStatus
{
    class ServiceHeartBeatJob : IJob
    {

        private readonly IHeartbeatService _hearbeat;
        IHRAMServicesService _IHRAMServicesService;

        private static readonly ILog s_log = LogManager.GetLogger<ServerStatusCheckerJob>();

        public ServiceHeartBeatJob(IHeartbeatService hearbeat, IHRAMServicesService iHRAMServicesService)
        {
            if (hearbeat == null) throw new ArgumentNullException(nameof(hearbeat));
            _hearbeat = hearbeat;
            this._IHRAMServicesService = iHRAMServicesService;
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
                DateTime heartBeat = new DateTime();
                heartBeat = DateTime.Now;
                WindowsServiceStatus windowsServiceStatus = new WindowsServiceStatus();

                windowsServiceStatus.HeartBeatValue = heartBeat;
                windowsServiceStatus.RunningServerName = System.Environment.MachineName;
                windowsServiceStatus.ServiceName = ServiceGlobalVariable.ServiceName;

                this._IHRAMServicesService.UpdateServerServiceStatusBatch(windowsServiceStatus);

                // Get the context for the Pusher hub
                IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                hubContext.Clients.All.addMessage(ServiceGlobalVariable.ServiceName 
                                    , heartBeat.ToString());
                
            }

           
        }

    }
}
