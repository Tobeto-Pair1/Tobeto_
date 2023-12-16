using Business.Abstract;
using Business.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // services.AddScoped<IUserService, UserManager>();

           
           
            //services.AddScoped<CategoryBusinessRules>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<IEducationService, EducationManager>();

            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ITownService, TownManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<ISectorService, SectorManager>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddSubClassesOfType(
    this IServiceCollection services,
    Assembly assembly,
    Type type,
    Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);

                else
                    addWithLifeCycle(services, type);
            return services;
        }

    }
}