using Autofac;
using Autofac.Extras.Quartz;
using System.Collections.Specialized;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerStatusChecker
{
    internal class Bootstrap
    {
        public static void InitializeLogger()
        {
            var log = new LoggerConfiguration()              
                .CreateLogger();
            Log.Logger = log;
        }

        internal static ContainerBuilder ConfigureContainer(ContainerBuilder cb)
        {
            // configure and register Quartz
            var schedulerConfig = new NameValueCollection {
                {"quartz.threadPool.threadCount", "3"},
                {"quartz.scheduler.threadName", "Scheduler"}
            };

            cb.RegisterModule(new QuartzAutofacFactoryModule
            {
                ConfigurationProvider = c => schedulerConfig
            });
            cb.RegisterModule(new QuartzAutofacJobsModule(typeof(HeartbeatJob).Assembly));
            cb.RegisterModule(new DependencyInjecionResolver.ServiceDIContainer());
            RegisterComponents(cb);
            return cb;
        }

        internal static void RegisterComponents(ContainerBuilder cb)
        {
            // register dependencies
            cb.RegisterType<HeartbeatService>().As<IHeartbeatService>();
        }
    }
}
