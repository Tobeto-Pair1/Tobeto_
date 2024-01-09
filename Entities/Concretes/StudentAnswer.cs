using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class StudentAnswer:Entity<Guid>
    {
        public Guid StudentId {  get; set; }
        public Guid QuestionId { get; set; }
        public Student Student { get; set; }
        public Question Question { get; set; }
        public char SelectedOption { get; set; }
        public bool IsCorrect { get; set; }
    }

}
