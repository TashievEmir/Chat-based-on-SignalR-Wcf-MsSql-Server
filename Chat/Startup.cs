using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Chat.Startup))]

namespace Chat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            app.MapSignalR();
        }
    }
}
