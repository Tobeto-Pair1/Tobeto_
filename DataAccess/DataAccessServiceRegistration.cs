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
        //    options.UseSqlServer("TobetoDB",
        //    b => b.MigrationsAssembly("DataAccess")));


        services.AddScoped<IForeignLanguageDal, EfForeignLanguageDal>();
        services.AddScoped<IForeignLanguageLevelDal, EfForeignLanguageLevelDal>();
        services.AddScoped<IUserLanguageDal, EfUserLanguageDal>();

        services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
        services.AddScoped<IUserSocialDal, EfUserSocialDal>();


        services.AddScoped<IAboutOfCourseDal, EfAboutOfCourseDal>();
        services.AddScoped<INotificationDal, EfNotificationDal>();
        services.AddScoped<INotificationTypeDal, EfNotificationTypeDal>();
        services.AddScoped<IEmployeeDal, EfEmployeeDal>();
        services.AddScoped<IAddressDal, EfAddressDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IInstructorDal, EfInstructorDal>();
        services.AddScoped<IStudentDal, EfStudentDal>();
        services.AddScoped<IAsyncLessonDal, EfAsyncLessonDal>();
        services.AddScoped<ITownDal, EfTownDal>();
        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<ISkillDal, EfSkillDal>();
        services.AddScoped<ISectorDal, EfSectorDal>();
        services.AddScoped<IHomeworkDal, EfHomeworkDal>();
        services.AddScoped<ISynchronLessonDal, EfSynchronLessonDal>();
        services.AddScoped<IUserEducationDal, EfUserEducationDal>();
        services.AddScoped<ICityDal, EfCityDal>();
        services.AddScoped<ISynchronLessonDetailDal, EfSynchronLessonDetailDal>();
        services.AddScoped<ISynchronLessonInstructorDal, EfSynchronLessonInstructorDal>();
        services.AddScoped<IUserSkillDal, EfUserSkillDal>();
        services.AddScoped<ISubTypeDal, EfSubTypeDal>();
        services.AddScoped<IProgramDal, EfProgramDal>();
        services.AddScoped<ICompanyDal, EfCompanyDal>();
        services.AddScoped<IExperienceDal, EfExperienceDal>();

       





        return services;
    }
}
