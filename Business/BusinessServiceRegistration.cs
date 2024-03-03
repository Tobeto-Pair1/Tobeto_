using Microsoft.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using System.Reflection;
using Core.Business;
using FluentValidation;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Autofac;
using Autofac.Extras.DynamicProxy;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IUserLanguageService, UserLanguageManager>();
        services.AddScoped<IForeignLanguageService, ForeignLanguageManager>();
        services.AddScoped<IForeignLanguageLevelService, ForeignLanguageLevelManager>();
        services.AddScoped<ISocialMediaService, SocialMediaManager>();
        services.AddScoped<IUserSocialService, UserSocialManager>();
        services.AddScoped<IUserSkillService, UserSkillManager>();
        services.AddScoped<ISkillService, SkillManager>();
        services.AddScoped<ICertificateService, CertificateManager>();
        services.AddScoped<IUserEducationService, UserEducationManager>();
        services.AddScoped<IExperienceService, ExperienceManager>();

        services.AddScoped<INotificationService, NotificationManager>();
        services.AddScoped<IBlogService, BlogManager>();
        services.AddScoped<IBlogPressService, BlogPressManager>();

        services.AddScoped<ICourseService, CourseManager>();
        services.AddScoped<ICourseModuleService, CourseModuleManager>();
        services.AddScoped<ICourseProgramService, CourseProgramManager>();
        services.AddScoped<ICourseStudentService, CourseStudentManager>();
        services.AddScoped<ICourseTypeService, CourseTypeManager>();
        services.AddScoped<IAboutOfCourseService, AboutOfCourseManager>();
        services.AddScoped<IAsyncLessonService, AsyncLessonManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IHomeworkService, HomeworkManager>();
        services.AddScoped<ISynchronLessonService, SynchronLessonManager>();
        services.AddScoped<IAsyncLessonDetailService, AsyncLessonDetailManager>();
        services.AddScoped<ISynchronLessonDetailService, SynchronLessonDetailManager>();
        services.AddScoped<ISynchronLessonInstructorService, SynchronLessonInstructorManager>();
        services.AddScoped<ILessonLanguageService, LessonLanguageManager>();
        services.AddScoped<ISubTypeService, SubTypeManager>();
        services.AddScoped<IProgramService, ProgramManager>();
        services.AddScoped<IManufacturerService, ManufacturerManager>();


        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<ICountryService, CountryManager>();
        services.AddScoped<ICityService, CityManager>();
        services.AddScoped<ITownService, TownManager>();

        services.AddScoped<IExamService, ExamManager>();
        services.AddScoped<IGradeService, GradeManager>();
        services.AddScoped<IQuestionService, QuestionManager>();
        services.AddScoped<IStudentAnswerService, StudentAnswerManager>();


        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<IEmployeeOperationClaimService, EmployeeOperationClaimManager>();
        services.AddScoped<IEmployeeAuthService, AuthEmployeeManager>();

        services.AddScoped<IInstructorService, InstructorManager>();
        services.AddScoped<IInstructorOperationClaimService, InstructorOperationClaimManager>();
        services.AddScoped<IInstructorAuthService, AuthInstructorManager>();


        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        services.AddScoped<IAuthService, AuthManager>();

        services.AddScoped<IImageService, ImageManager>();

        services.AddScoped<IContactInformationService, ContactInformationManager>();


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

}