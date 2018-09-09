using Autofac;
using Autofac.Extras.Quartz;
using Autofac.Features.OwnedInstances;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using Quartz.Spi;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace ServerStatusChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureService.Configure();
        }

        internal static class ConfigureService
        {
            internal static void Configure()
            {
                HostFactory.Run(configure =>
                {
                    configure.Service<ServerStatusChecker>(service =>
                    {
                        service.ConstructUsing(s => new ServerStatusChecker());
                        service.WhenStarted(s => s.Start());
                        service.WhenStopped(s => s.Stop());
                    });
                    //Setup Account that window service use to run.  
                    configure.RunAsLocalSystem();
                    configure.SetServiceName("MyWindowServiceWithTopshelf4");
                    configure.SetDisplayName("MyWindowServiceWithTopshelf4");
                    configure.SetDescription("My .Net windows service with Topshelf");
                });
            }
        }
    }




  
    public class ServerStatusChecker
    {
      

        public void Start()
        {

            Bootstrap.InitializeLogger();
         
            var container = Bootstrap.ConfigureContainer(new ContainerBuilder()).Build();

            container = Bootstrap.ConfigureContainer(new ContainerBuilder()).Build();
            var job = JobBuilder.Create<HeartbeatJob>().WithIdentity("Heartbeat", "Maintenance").Build();
            var trigger = TriggerBuilder.Create()
                .WithIdentity("Heartbeat", "Maintenance")
                .StartNow()
                .WithSchedule(SimpleScheduleBuilder.RepeatSecondlyForever(20)).Build();
            var cts = new CancellationTokenSource();

            var scheduler = container.Resolve<IScheduler>();
            scheduler.ScheduleJob(job, trigger, cts.Token);

            scheduler.Start();

         
            //scheduler.Start().Wait();

            //Console.WriteLine("======================");
            //Console.WriteLine("Press Enter to exit...");
            //Console.WriteLine("======================");
            //Console.ReadLine();

            //cts.Cancel();
            //scheduler.Shutdown().Wait();

        }
        public void Stop()
        {
            // write code here that runs when the Windows Service stops.  
        }
    }

    


    public class AutofacJobFactory : IJobFactory
    {
        private readonly IContainer _container;

        public AutofacJobFactory(IContainer container)
        {
            _container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return (IJob)_container.Resolve(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job)
        {
        }
    }


  
}
