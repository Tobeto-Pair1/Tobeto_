using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.AsyncLessonDetail
{
    public class GetListAsyncLessonDetailResponse
    {
        public Guid Id { get; set; }
        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }
        public string AsyncLessonName { get; set; }
        public string LessonLanguageName { get; set; }
        public string SubTypeName { get; set; }
    }
}
