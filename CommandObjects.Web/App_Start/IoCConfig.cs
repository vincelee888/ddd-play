using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CommandObjects.BookingsServiceWebAdapter;
using CommandObjects.BookingsServiceInterface;
using TinyIoC;

namespace CommandObjects.Web
{
    public static class IoCConfig    
    {
        public static void Register()
        {
            var container = TinyIoCContainer.Current;

            container.Register<IGetBookingsServiceAdapter<ActionResult>, GetBookingsServiceWebAdapter>();
            container.Register<IBookingsService, BookingsService>();

            DependencyResolver.SetResolver(new TinyIocMvcDependencyResolver(container));
        }
    }

    public class TinyIocMvcDependencyResolver : IDependencyResolver
    {
        private readonly TinyIoCContainer _container;

        public TinyIocMvcDependencyResolver(TinyIoCContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType, true);
            }
            catch (Exception)
            {
                return Enumerable.Empty<object>();
            }
        }
    }
}
