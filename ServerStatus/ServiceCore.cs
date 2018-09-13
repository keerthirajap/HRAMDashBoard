using System;
using Common.Logging;
using Quartz;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;
using System.Threading;
using ServerStatus;


class Startup
{
    public void Configuration(IAppBuilder app)
    {
        app.UseCors(CorsOptions.AllowAll);
        app.MapSignalR();
    }

}

public class ServiceCore : Hub
{


    private static readonly ILog s_log = LogManager.GetLogger<ServiceCore>();
    private readonly IScheduler _scheduler;

    public ServiceCore(IScheduler scheduler)
    {
        if (scheduler == null) throw new ArgumentNullException(nameof(scheduler));

        _scheduler = scheduler;
    }

    public bool Start()
    {

  

        s_log.Info("Service started");

        if (!_scheduler.IsStarted)
        {
            s_log.Info("Starting Scheduler");

            _scheduler.Start();
        }
        return true;
    }

    public bool Stop()
    {
        s_log.Info("Stopping Scheduler...");
        _scheduler.Shutdown(true);

        s_log.Info("Service stopped");
        return true;
    }

}