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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Business;
using Core.Utilities.Security.JWT;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {

            services.AddScoped<IUserLanguageService, UserLanguageManager>();
            services.AddScoped<IForeignLanguageService, ForeignLanguageManager>();
            services.AddScoped<IForeignLanguageLevelService, ForeignLanguageLevelManager>();



            services.AddScoped<IAboutOfCourseService, AboutOfCourseManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<IAddressService, AddressManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IInstructorService, InstructorManager>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<IStudentService, StudentManager>();
            services.AddScoped<IAsyncLessonService, AsyncLessonManager>();
            services.AddScoped<ITownService, TownManager>();
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
            services.AddScoped<IExamService, ExamManager>();
            services.AddScoped<IGradeService, GradeManager>();
            services.AddScoped<IQuestionService, QuestionManager>();
            services.AddScoped<IStudentAnswerService, StudentAnswerManager>();
            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<IAsyncLessonDetailService, AsyncLessonDetailManager>();
            services.AddScoped<ICountryService, CountryManager>();
            services.AddScoped<ICertificateService, CertificateManager>();

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
            services.AddScoped<ITokenHelper, JwtHelper>();




            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection AddSubClassesOfType(this IServiceCollection services,
         Assembly assembly, Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
            foreach (var item in types)
                if (addWithLifeCycle == null)
                    services.AddScoped(item);

                else
                    addWithLifeCycle(services, type);
            return services;
        }


        public static void AddJwtBearerAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configuration =>
            {
                configuration.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,

                    ValidIssuer = "Ahmet Güzeller",
                    ValidAudience = "IT Desk",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AdnanşensesAdnanşensesAdnanşensesAdnanşensesAdnanşenses"))
                };
            });
        }






    }


}