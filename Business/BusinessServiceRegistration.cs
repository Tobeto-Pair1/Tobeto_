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
using Business.Profiles;
using Business.DTOs.UserLanguages;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IAboutOfCourseService, AboutOfCourseManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<IForeignLanguageService, ForeignLanguageManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IAsyncLessonService, AsyncLessonManager>();
            services.AddScoped<ITownService, TownManager>();
            services.AddScoped<IUserLanguageService, UserLanguageManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ISkillService, SkillManager>();
            services.AddScoped<ISectorService, SectorManager>();
            services.AddScoped<IHomeworkService, HomeworkManager>();
            services.AddScoped<ISynchronLessonService, SynchronLessonManager>();
            services.AddScoped<IUserEducationService, UserEducationManager>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<ISynchronLessonDetailService, SynchronLessonDetailManager>();
            services.AddScoped<ISynchronLessonInstructorService, SynchronLessonInstructorManager>();
            services.AddScoped<IUserSocialService, UserSocialManager>();
            services.AddScoped<IUserSkillService, UserSkillManager>();
            services.AddScoped<ISubTypeService, SubTypeManager>();
            services.AddScoped<IProgramService, ProgramManager>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<IExperienceService, ExperienceManager>();

            services.AddScoped<ICompanyService, CompanyManager>();

           






            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services,
         Assembly assembly,Type type,Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
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