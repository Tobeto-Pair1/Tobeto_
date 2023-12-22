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
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concretes;
using System.Reflection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {


        //services.AddDbContext<TobetoDbContext>(options => options.UseInMemoryDatabase("TobetoDbContext"));

        services.AddDbContext<TobetoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TobetoDB")));

        //services.AddDbContext<TobetoDbContext>(options =>
        //    options.UseSqlServer("Data Source=DESKTOP-3O4V1S5;Initial Catalog=Tobeto_Database;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False",
        //    b => b.MigrationsAssembly("WebAPI")));



        services.AddScoped<IAboutOfCourseDal, EfAboutOfCourseDal>();
        services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
        services.AddScoped<IEmployeeDal, EfEmployeeDal>();
        services.AddScoped<IAddressDal, EfAddressDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IInstructorDal, EfInstructorDal>();
        services.AddScoped<ILanguageDal, EfLanguageDal>();
        services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
        services.AddScoped<IStudentDal, EfStudentDal>();
        services.AddScoped<IAsyncLessonDal, EfAsyncLessonDal>();
        services.AddScoped<ITownDal, EfTownDal>();
        services.AddScoped<IUserLanguageDal, EfUserLanguageDal>();
        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<ISkillDal, EfSkillDal>();
        services.AddScoped<ISectorDal, EfSectorDal>();
        services.AddScoped<IHomeworkDal, EfHomeworkDal>();
        services.AddScoped<INewDal, EfNewDal>();
        services.AddScoped<ISynchronLessonDal, EfSynchronLessonDal>();
        services.AddScoped<IUserEducationDal, EfUserEducationDal>();
        services.AddScoped<ICityDal, EfCityDal>();






        return services;
    }
}
