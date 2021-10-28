using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ODataIOCWebAPI.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using ODataIOCWebAPI.IOC;
using ODataIOCWebAPI.IOC.IRepositories;
using ODataIOCWebAPI.IOC.Repositories;
using Unity;
using Unity.Lifetime;

namespace ODataIOCWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            //container.RegisterInstance<IDbContextRepository>(new DBContext(),new ContainerControlledLifetimeManager())
            container.RegisterType<IProductsRepository, ProductsRepository>(new TransientLifetimeManager());
            config.DependencyResolver = new IOCResolver(container);


            ODataModelBuilder builder = new ODataConventionModelBuilder();            
            builder.EntitySet<Product>("Products");
            config.MapODataServiceRoute(
                routeName:"api",
                routePrefix:null,
                model:builder.GetEdmModel()
                );
            // Web API configuration and services

            // Web API routes
            /*config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );*/
        }
    }
}
