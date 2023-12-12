using System;
using Core.Entities;

namespace Entities.Concretes
{
	public class EducationDetail:Entity<int>
	{
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public DateTime EstimatedTime { get; set; }
		public int CategoryId { get; set; }
		public int ContentId { get; set; }
		public int ManufacturerId { get; set; }
	}
}

