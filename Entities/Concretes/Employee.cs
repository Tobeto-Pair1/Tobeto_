using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class Employee:Entity<Guid>
	{
		public string Name { get; set; }
		public string DepartmentId {get; set;}
		public Guid UserId { get; set; }

        public virtual User User { get; set; }
    }

}





