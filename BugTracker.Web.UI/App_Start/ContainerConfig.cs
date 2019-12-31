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
using System.Web.Services.Description;

namespace BugTracker.Web.UI.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);            
         
            builder.RegisterType<BugTrackerContext>().As<IBugTrackerContext>().SingleInstance();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();
            builder.RegisterType<BugRepository>().As<IBugRepository>().InstancePerRequest();
            builder.RegisterType<TicketRepository>().As<ITicketRepository>().InstancePerRequest();
            builder.RegisterType<BugTracker.Infrastructure.Ticket>().As<BugTracker.Infrastructure.Specifications.ITicket>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));            
        }
    }
}