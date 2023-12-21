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
using Entities.Concretes;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {

        //services.AddDbContext<TobetoDbContext>(options => options.UseInMemoryDatabase("TobetoDB"));

        services.AddDbContext<TobetoDbContext>(options=>options.UseSqlServer(configuration.GetConnectionString("TobetoDB")));

        services.AddScoped<IAboutOfCourseDal, EfAboutOfCourseDal>();
        services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
        services.AddScoped<IEmployeeDal, EfEmployeeDal>();
        services.AddScoped<IAddressDal, EfAddressDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IEducationDal, EfEducationDal>();
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
        services.AddScoped<ISynchronLessonDal, EfSynchronLessonDal>();



        return services;
    }
}
