using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRHub2
{
    class Program 
    {
        static void Main(string[] args)
        {
          

            // This will *ONLY* bind to localhost, if you want to bind to all addresses
            // use http://*:8080 to bind to all addresses. 
            // See http://msdn.microsoft.com/library/system.net.httplistener.aspx 
            // for more information.
            string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }


        
    }

    class Startup 
    {
        public void Configuration(IAppBuilder app)
        {
            TimerCallback tmCallback = CheckEffectExpiry;
            Timer timer = new Timer(tmCallback, "test", 10000, 10000);
           


            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }

         void CheckEffectExpiry(object objectInfo)
        {
            Console.WriteLine("Press any key to exit the sample");

            // Get the context for the Pusher hub
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
            hubContext.Clients.All.addMessage("213", "4654646546");
            //TODO put your code
        }
    }
    public class MyHub : Hub
    {
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}
