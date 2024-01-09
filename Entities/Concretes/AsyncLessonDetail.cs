using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class AsyncLessonDetail : Entity<Guid>
{
    public Guid? ManufacturerId { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? AsyncLessonId { get; set; }
    public Guid? LessonLanguageId { get; set; }
    public Guid? SubTypeId { get; set; }

    public virtual Manufacturer Manufacturer { get; set; }
    public virtual Category Category  { get; set; }
    public virtual AsyncLesson  AsyncLesson  { get; set; }
    public virtual LessonLanguage LessonLanguage { get; set; } 
    public virtual SubType SubType { get; set; }

}