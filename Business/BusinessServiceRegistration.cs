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
            services.AddScoped<IUserService, UserManager>();

            //services.AddScoped<CategoryBusinessRules>();

            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<ILanguageService, LanguageManager>();
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}
