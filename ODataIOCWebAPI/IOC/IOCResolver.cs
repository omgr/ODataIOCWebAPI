using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using System.Web.Http.Dependencies;

namespace ODataIOCWebAPI.IOC
{
    public class IOCResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public IOCResolver(IUnityContainer container) {
            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            this.container = container;
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new IOCResolver(child);
        }

        public void Dispose()
        {
            Dispose(true); ;
        }
        protected virtual void Dispose(bool disposing)
        {
            container.Dispose();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException exception)
            {
                //throw new InvalidOperationException(
                //    $"Unable to resolve service for type {serviceType}.",
                //   exception);
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException exception)
            {
                /*throw new InvalidOperationException(
                    $"Unable to resolve service for type {serviceType}.",
                    exception);*/
                return null;
            }
        }
    }
}