using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Teacher
{
    public int Teacherid { get; set; }

    public string? Teachername { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
