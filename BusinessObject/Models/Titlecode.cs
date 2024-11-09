using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Titlecode
{
    public int Titlecodeid { get; set; }

    public int? Titlecodenumber { get; set; }

    public int? Classid { get; set; }

    public int? TeacherSubjectId { get; set; }

    public int? Totalmark { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

    public virtual Class? Class { get; set; }

    public virtual TeacherSubject? TeacherSubject { get; set; }
}
