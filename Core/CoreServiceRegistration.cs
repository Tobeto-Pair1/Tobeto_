using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.FileUpload;
using Core.Utilities.IoC;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core;

public static class CoreServiceRegistration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<ICacheManager, MemoryCacheManager>();

        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IFileUploadAdapter, CloudinaryAdapter>();

        services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
        ServiceTool.Create(services);

        return services;
    }
}

