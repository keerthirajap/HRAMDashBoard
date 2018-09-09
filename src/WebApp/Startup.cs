using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DependencyInjecionResolver;
using WebApp.Infrastructure;

using WebApp.Configuration;
using log4net.Appender;
using WebApp.Scheduler;
using WebApp;
using Hangfire;
using System.Diagnostics;
using Hangfire.Common;
using ServiceInterface;
using WebApp.Hubs;
using Microsoft.Owin;
using System.Reflection;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IContainer ApplicationContainer { get; private set; }
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(cc =>
       cc.UseSqlServerStorage("Data Source=.;Initial Catalog=HRAMDashBoard;Integrated Security=True"));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);




            services.AddSignalR(opt =>
             { opt.Hubs.EnableDetailedErrors = true; }
            );

            // Add framework services.
            services.AddMvc();

            // Create the container builder.
            var builder = new ContainerBuilder();

            builder.Populate(services);
            builder.RegisterModule(new ServiceDIContainer());
            builder.RegisterType<DashBoardHub>().ExternallyOwned(); // SignalR hub
          
          
            builder.RegisterType<DashBoardJob>().InstancePerDependency(); // Hangfire job

            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
                                                    ILoggerFactory loggerFactory
                                                , IApplicationLifetime appLifetime)
        {
            #region HangFire
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            BackgroundJob.Enqueue<DashBoardJob>(
                     x => x.Execute());

            RecurringJob.AddOrUpdate<DashBoardJob>("Recurring1", myService => myService.RecouringExecute(),
                                    Cron.MinuteInterval(1));

            RecurringJob.AddOrUpdate(() => Debug.WriteLine("Recurring!"), Cron.MinuteInterval(1));

            var jobId = BackgroundJob.Enqueue(
                     () => Debug.WriteLine("Fire-and-forget!"));
            #endregion


            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseSignalR();

            //app.UseSignalR(configure =>
            //{
            //    configure.MapHub<Hub>("hub", options =>
            //    {
            //        options.Transports = TransportType.All;
            //        options.LongPolling.PollTimeout = TimeSpan.FromSeconds(10);
            //        options.WebSockets.CloseTimeout = TimeSpan.FromSeconds(10);
            //    });
            //});


            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

     

    }



}
