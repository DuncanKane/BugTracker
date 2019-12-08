using Autofac;
using Autofac.Integration.Mvc;
using BugTracker.Data;
using BugTracker.Data.Context;
using BugTracker.Data.Interfaces;
using BugTracker.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracker.Web.UI.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);            
            //builder.RegisterType<>()
            //       .As<>()
            //       .InstancePerRequest();
            builder.RegisterType<BugTrackerContext>().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            //builder.RegisterType<Repository>().As<IRepository>().InstancePerRequest();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
        }
    }
}