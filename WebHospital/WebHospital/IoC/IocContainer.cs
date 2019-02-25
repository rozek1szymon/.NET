using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WebHospital.Models;

namespace Test
{
    public static class IoC
    {
        public static MainDb GetMainDb()
        {
            return IoCContainer.Provider.GetService<MainDb>();
        }
    }


    public static class IoCContainer
    {
        public static IServiceProvider Provider { get; set; }
        public static IConfiguration Configuration { get; set; }
    }
}
