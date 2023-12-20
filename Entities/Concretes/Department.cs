using Core.Entities;

namespace Entities.Concretes
{
    public class Department:Entity<Guid>
	{
	    public string Name { get; set; }

		public virtual ICollection<Employee> Employees { get;}

	}
}





