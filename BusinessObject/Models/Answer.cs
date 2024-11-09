using System;
using System.Collections.Generic;

namespace BusinessObject.Models;

public partial class Answer
{
    public int Idcauhoi { get; set; }

    public int? Causo { get; set; }

    public string? Dapan { get; set; }

    public int? Idmade { get; set; }

    public virtual Titlecode? IdmadeNavigation { get; set; }
}
