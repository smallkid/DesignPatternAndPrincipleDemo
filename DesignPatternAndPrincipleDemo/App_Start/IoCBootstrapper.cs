using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;
using darkstar.core;
using DesignPatternAndPrincipleDemo;
using System.Web.Http;
using Autofac.Integration.WebApi;

namespace DesignPatternAndPrincipleDemo
{
    public class IoCBootstrapper
    {
        public static void RegisterDependencies() {
            var builder = new ContainerBuilder();
            var ctx = new CompanyCtx();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(DesignPatternAndPrincipleDemo.Controllers.EmployeeAPIController).Assembly);

            builder.Register(x => new EmployeeRepository(ctx)).As<IEmployeeRepository>().InstancePerLifetimeScope();
            builder.Register(x => new DepartmentRepository(ctx)).As<IDepartmentRepository>().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));



            /*webapi*/
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}