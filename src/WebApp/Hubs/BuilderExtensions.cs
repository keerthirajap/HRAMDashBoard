using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Hubs
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Owin.Builder;
    using Owin;
    using AppFunc = Func<IDictionary<string, object>, Task>;

    public static class BuilderExtensions
    {
        //public static IApplicationBuilder UseAppBuilder(
        //    this IApplicationBuilder app,
        //    Action<IAppBuilder> configure)
        //{
        //    app.UseOwin(addToPipeline =>
        //    {
        //        addToPipeline(next =>
        //        {
        //            var appBuilder = new AppBuilder();
        //            appBuilder.Properties["builder.DefaultApp"] = next;

        //            configure(appBuilder);

        //            return appBuilder.Build<AppFunc>();
        //        });
        //    });

        //    return app;
        //}

        //public static void UseSignalR2(this IApplicationBuilder app)
        //{
        //    app.UseAppBuilder(appBuilder => appBuilder.MapSignalR());
        //}
    }
}
