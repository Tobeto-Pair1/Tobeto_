using Entities.Concrete;
using Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context;
public class TobetoDbContext : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>,
        IdentityUserRole<Guid>, IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
{
    protected IConfiguration Configuration { get; set; }



    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }



    public DbSet<AboutOfCourse> AboutOfCourses { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationType> NotificationTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserEducation> UserEducations { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<ForeignLanguage> ForeignLanguages { get; set; }
    public DbSet<UserLanguage> UserLanguages { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<AsyncLesson> AsyncLessons { get; set; }
    public DbSet<SynchronLesson> SynchronLessons { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<SynchronLessonDetail> SynchronLessonDetails { get; set; }
    public DbSet<SynchronLessonInstructor> SynchronLessonInstructors { get; set; }
    public DbSet<UserSocial> UserSocials { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<SubType> SubTypes { get; set; }
    public DbSet<Program> Programs { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Company> Companies { get; set; }



    public TobetoDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
       // Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }




        #region identity


        modelBuilder.Entity<IdentityUserRole<Guid>>().HasNoKey();


        modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.RoleId });
        });

        modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
        });


        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<AppRole>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
         modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
    {
        entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        // Diğer yapılandırmalar...
    });
    }
        #endregion
}
