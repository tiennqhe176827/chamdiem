using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Subjecttable
{
    public int Subjectid { get; set; }

    public string Subjectname { get; set; } = null!;

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
