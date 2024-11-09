using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class TeacherSubject
{
    public int Id { get; set; }

    public int? Teacherid { get; set; }

    public int? Subjectid { get; set; }

    public virtual Subjecttable? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }

    public virtual ICollection<Titlecode> Titlecodes { get; set; } = new List<Titlecode>();
}
