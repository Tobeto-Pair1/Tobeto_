using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class Category : Entity<Guid>
	{
        public string Name{ get; set; }
        public Guid? ParentId { get; set; }


        public virtual ICollection<Category> SubCategory { get; set; }
        public virtual Category ParentCategory { get; set; }
        public  virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<SynchronLessonDetail> SynchronLessonDetails { get; set; }
        public virtual ICollection<AsyncLessonDetail> AsyncLessonDetails { get; set; }
    }
}

