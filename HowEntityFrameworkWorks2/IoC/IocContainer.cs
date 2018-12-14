using Microsoft.Extensions.DependencyInjection;
using System;


namespace EntityFrameworkBasics
{
    public static class IoC
    {
        public static ApplicationDbContext ApplicationDbContext => IoCContainer.Provider.GetService<ApplicationDbContext>();
    }

    public static class IoCContainer
    {
        public static ServiceProvider Provider  {get; set;}
    }
}
