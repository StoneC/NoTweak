using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using NoTweak.Web.IoC;
using NoTweak.Data;
using NoTweak.Service;
using NoTweak.Data.Infrastructure;

namespace NoTweak.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            IUnityContainer container = GetUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private IUnityContainer GetUnityContainer()
        {
            //Create UnityContainer          
            IUnityContainer container = new UnityContainer()
                //.RegisterType<IControllerActivator, CustomControllerActivator>() // No nned to a controller activator
            .RegisterType<IDatabaseFactory, DatabaseFactory>(new HttpContextLifetimeManager<IDatabaseFactory>())
            .RegisterType<IUnitOfWork,UnitOfWork>(new HttpContextLifetimeManager<IUnitOfWork>())
            .RegisterType<IRestaurantRepository, RestaurantRepository>(new HttpContextLifetimeManager<IRestaurantRepository>())
            .RegisterType<IRestaurantService, RestaurantService>(new HttpContextLifetimeManager<IRestaurantService>())
            .RegisterType<IDishRepository, DishRepository>(new HttpContextLifetimeManager<IDishRepository>())
            .RegisterType<IDishService, DishService>(new HttpContextLifetimeManager<IDishService>());
            return container;
        }
    }
}