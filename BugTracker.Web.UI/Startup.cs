using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BugTracker.Web.StartUp))]
namespace BugTracker.Web 
{
    public partial class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAuth(app);
        }
    }
}