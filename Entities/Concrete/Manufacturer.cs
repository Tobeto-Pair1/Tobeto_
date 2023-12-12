using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
namespace Entities
{
	public class Manufacturer :Entity<int>
	{
		public string ManufacturerName { get; set; }
	}
}

