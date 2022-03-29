using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileTime.Helper
{
    public static class ServiceResolverStartup
    {

        public static void UseServiceResolver(this IServiceCollection sc)
        {
            var sp = sc.BuildServiceProvider();
            ServiceResolver.RegisterServiceProvider(sp);
        }

        public static MauiAppBuilder UseServiceResolver(this MauiAppBuilder builder)
        {
            var sp = builder.Services.BuildServiceProvider();
            ServiceResolver.RegisterServiceProvider(sp);
            return builder;
        }

    }
}
