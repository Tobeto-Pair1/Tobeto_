﻿using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddDbContext<NorthwindContext>(options => options.UseInMemoryDatabase("nArchitecture"));

        services.AddDbContext<NorthwindContext>(options=>options.UseSqlServer(configuration.GetConnectionString("ETradeC")));

        //services.AddScoped<IProductDal, EfProductDal>();
        //services.AddScoped<ICategoryDal, EfCategoryDal>();

        return services;
    }
}
