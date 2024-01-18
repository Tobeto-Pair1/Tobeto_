using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Grade : Entity<Guid>
    {
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public double Score { get; set; }
    }

}
