using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DataAccess.Abstract;
using DataAccess.Concrete;



namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TobetoDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TobetoDB")));
      
        services.AddScoped<IForeignLanguageDal, EfForeignLanguageDal>();
        services.AddScoped<IForeignLanguageLevelDal, EfForeignLanguageLevelDal>();
        services.AddScoped<IUserLanguageDal, EfUserLanguageDal>();
        services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
        services.AddScoped<IUserSocialDal, EfUserSocialDal>();
        services.AddScoped<IUserEducationDal, EfUserEducationDal>();
        services.AddScoped<IUserSkillDal, EfUserSkillDal>();
        services.AddScoped<ICompanyDal, EfCompanyDal>();
        services.AddScoped<IExperienceDal, EfExperienceDal>();
        services.AddScoped<ICertificateDal, EfCertificateDal>();


        services.AddScoped<ISkillDal, EfSkillDal>();
        services.AddScoped<ISectorDal, EfSectorDal>();

        services.AddScoped<ICourseTypeDal, EfCourseTypeDal>();
        services.AddScoped<IAboutOfCourseDal, EfAboutOfCourseDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<IAsyncLessonDal, EfAsyncLessonDal>();
        services.AddScoped<ISynchronLessonDal, EfSynchronLessonDal>();
        services.AddScoped<ISynchronLessonDetailDal, EfSynchronLessonDetailDal>();
        services.AddScoped<ISynchronLessonInstructorDal, EfSynchronLessonInstructorDal>();
        services.AddScoped<ISubTypeDal, EfSubTypeDal>();
        services.AddScoped<IProgramDal, EfProgramDal>();
        services.AddScoped<IHomeworkDal, EfHomeworkDal>();
        services.AddScoped<ICourseDal, EfCourseDal>();
        services.AddScoped<ICourseModuleDal, EfCourseModuleDal>();
        services.AddScoped<ICourseProgramDal, EfCourseProgramDal>();
        services.AddScoped<ICourseStudentDal, EfCourseStudentDal>();
        services.AddScoped<IAsyncLessonDetailDal, EfAsyncLessonDetailDal>();


        services.AddScoped<IAddressDal, EfAddressDal>();
        services.AddScoped<ICountryDal, EfCountryDal>();
        services.AddScoped<ICityDal, EfCityDal>();
        services.AddScoped<ITownDal, EfTownDal>();


        services.AddScoped<INotificationDal, EfNotificationDal>();
        services.AddScoped<INotificationTypeDal, EfNotificationTypeDal>();
        services.AddScoped<IBlogDal, EfBlogDal>();
        services.AddScoped<IBlogPressDal, EfBlogPressDal>();


        services.AddScoped<IExamDal, EfExamDal>();
        services.AddScoped<IGradeDal, EfGradeDal>();
        services.AddScoped<IQuestionDal, EfQuestionDal>();
        services.AddScoped<IStudentAnswerDal, EfStudentAnswerDal>();


        services.AddScoped<IEmployeeDal, EfEmployeeDal>();
        services.AddScoped<IEmployeeOperationClaimDal, EfEmployeeOperationClaimDal>();

        services.AddScoped<IInstructorDal, EfInstructorDal>();
        services.AddScoped<IInstructorOperationClaimDal, EfInstructorOperationClaimDal>();
  

        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<IUserOperationClaimDal, EfUserOperationClaimDal>();

     
        services.AddScoped<IImageDal, EfImageDal>();

        services.AddScoped<IStudentDal, EfStudentDal>();

        return services;
    }
}
