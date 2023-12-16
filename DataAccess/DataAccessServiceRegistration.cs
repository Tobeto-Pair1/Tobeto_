using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {

        //Data Source=DESKTOP-3O4V1S5;Initial Catalog=Tobeto;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
        services.AddDbContext<TobetoDbContext>(options => options.UseInMemoryDatabase("TobetoDbContext"));

        services.AddDbContext<TobetoDbContext>(options=>options.UseSqlServer(configuration.GetConnectionString("Data Source=DESKTOP-3O4V1S5;Initial Catalog=Tobeto;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")));

        services.AddScoped<IAddressDal, EfAddressDal>();

        services.AddScoped<ILanguageDal, EfLanguageDal>();
        services.AddScoped<IUserDal, EfUserDal>();

        services.AddScoped<ITownDal, EfTownDal>();
        services.AddScoped<ISkillDal, EfSkillDal>();




        //services.AddScoped<ICategoryDal, EfCategoryDal>();


        return services;
    }
}
