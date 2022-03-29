using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Helper
{
    public static class ServiceResolver
    {
        private static IServiceScope _serviceScope;

        internal static void RegisterServiceProvider(IServiceProvider sp)
        {
           _serviceScope = sp.CreateScope();
        }

        internal static T Resolve<T>() where T : class
        {
            var result = _serviceScope.ServiceProvider.GetRequiredService<T>();
            return result;        
        }

        internal static IServiceProvider GetServiceProvider()
        {
            return _serviceScope.ServiceProvider;
        }

    }
}
