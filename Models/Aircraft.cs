using System;
using System.Collections.Generic;

namespace FSAproject.Models;

public partial class Aircraft
{
    public string Immatriculation { get; set; }

    public int IdCompagnie { get; set; }

    public string? Type { get; set; }

    public int? NbSiege { get; set; }

    public virtual Compagnie? IdCompagnieNavigation { get; set; } = null;

    public virtual ICollection<Vol> Vols { get; set; } = new List<Vol>();
}
