using BugTracker.Data.Context;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
//using Microsoft.Owin.Security.Google;

namespace BugTracker.Web
{
	public partial class StartUp
	{
		public void ConfigAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(BugTrackerContext.Create);
		
        }
	}
}