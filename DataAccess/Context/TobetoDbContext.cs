using Entities.Concrete;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context;
public class TobetoDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<AboutOfCourse> AboutOfCourses { get; set; }
    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserEducation> Educations { get; set; }
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
    public DbSet<Town> Town { get; set; }
    public DbSet<Skill> Skill { get; set; }
    public DbSet<NotificationType> NotificationTypes {get; set;}
    public DbSet<Employee> Employees { get; set; }
    public DbSet<AsyncLesson> AsyncLessons { get; set; }

    public TobetoDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
