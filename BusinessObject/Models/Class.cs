using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Class
{
    public int Classid { get; set; }

    public string? Classname { get; set; }

    public virtual ICollection<Titlecode> Titlecodes { get; set; } = new List<Titlecode>();
}
