
using Autofac;
using Autofac.Extras.Quartz;

using Quartz;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Quartz;
using Topshelf.ServiceConfigurators;

namespace ServerStatusChecker
{
    public class MyService
    {
        static IContainer _container;

        public void Start()
        {
            Console.WriteLine("TopShelf Service Started");

            _container = ConfigureContainer(new ContainerBuilder()).Build();

            ScheduleJobServiceConfiguratorExtensions.SchedulerFactory = () => _container.Resolve<IScheduler>();

            HostFactory.Run(conf => {
                conf.SetServiceName("AutofacExtras.Quartz.Sample");
                conf.SetDisplayName("Quartz.Net integration for Autofac");
              
                conf.UseAutofacContainer(_container);

                conf.Service<ServiceCore>(svc => {
                    svc.ConstructUsingAutofacContainer();
                    svc.WhenStarted(o => o.Start());
                    svc.WhenStopped(o => {
                        o.Stop();
                        _container.Dispose();
                    });
                    ConfigureScheduler(svc);
                });
            });


            // write code here that runs when the Windows Service starts up.  
        }
        public void Stop()
        {
            // write code here that runs when the Windows Service stops.  
        }

        static void ConfigureScheduler(ServiceConfigurator<ServiceCore> svc)
        {
            svc.ScheduleQuartzJob(q => {
              
                q.WithJob(JobBuilder.Create<HeartbeatJob>()
                    .WithIdentity("Heartbeat", "Maintenance")
                    .Build);
                q.AddTrigger(() => TriggerBuilder.Create()
                    .WithSchedule(SimpleScheduleBuilder.RepeatSecondlyForever(2)).Build());
            });
        }

        internal static ContainerBuilder ConfigureContainer(ContainerBuilder cb)
        {
            // configure and register Quartz
            var schedulerConfig = new NameValueCollection {
                {"quartz.threadPool.threadCount", "3"},
                {"quartz.threadPool.threadNamePrefix", "SchedulerWorker"},
                {"quartz.scheduler.threadName", "Scheduler"}
            };

            cb.RegisterModule(new QuartzAutofacFactoryModule
            {
                ConfigurationProvider = c => schedulerConfig
            });
            cb.RegisterModule(new QuartzAutofacJobsModule(typeof(HeartbeatJob).Assembly));

            RegisterComponents(cb);
            return cb;
        }

        internal static void RegisterComponents(ContainerBuilder cb)
        {
            // register Service instance
            cb.RegisterType<ServiceCore>().AsSelf();
            // register dependencies
            cb.RegisterType<HeartbeatService>().As<IHeartbeatService>();
        }
    }
}
