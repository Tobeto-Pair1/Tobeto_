using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class Instructor : Entity<Guid>
{
    public Guid? ImageId { get; set; }
    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public string? IdentityNumber { get; set; }
    public DateTime? BirthDate { get; set; }

    public virtual SynchronLessonInstructor SynchronLessonInstructor { get; set; }
    public virtual ICollection<AsyncLesson> AsyncLessons { get; set; }
}
