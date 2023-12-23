using System;
using Core.Entities;

namespace Entities.Concretes;

public class SynchronLesson : Entity<Guid>
{

    public string SessionName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime TimeSpent { get; set; }


    //  public string SessionRecording { get; set; }

    // query yazılıp ders ile ilgili olan hocalar çekilecek comboboxdan aralarından seçim yaptırılacak**
    public virtual ICollection<SynchronLessonInstructor> SynchronLessonInstructor { get; set; }
}

