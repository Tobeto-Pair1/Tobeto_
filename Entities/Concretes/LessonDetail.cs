using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes;

public class LessonDetail : Entity<int>
{

    public string CourseCategory { get; set; }

    //language tablosu eklenecek 
    public string Language { get; set; }
    public int ManufacturerId { get; set; }

    //alt tip oluşturulacak !
    public Manufacturer Manufacturer { get; set; }

    public string Description { get; set; }
    public int LessonId { get; set; }



   





}
