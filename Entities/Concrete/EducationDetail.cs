using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Entities
{
	public class EducationDetail:Entity<int>
	{
		public DateTime StartedTime { get; set; }
		public DateTime EstimatedTime { get; set; }
		public int ContentId { get; set; }
		public int ManufacturerId { get; set; }

    }
}

