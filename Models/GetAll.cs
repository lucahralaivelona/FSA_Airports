using FSAproject.Models;
using System;
using System.Collections.Generic;

namespace FSAproject.Models;


public partial class GettAll
{
    public int NumeroVol { get; set; }

    public int Immatriculation { get; set; }

    public string Resau { get; set; } = null!;

    public TimeSpan HeurePiste { get; set; }

    public TimeSpan HeureBloc { get; set; }

    public string DestProv { get; set; } = null!;

    public int? PaxC { get; set; }

    public int? PaxY { get; set; }

    public int Total { get; set; }

    public int Immd { get; set; }

    public short Annee { get; set; }

    public DateTime Mois { get; set; }

    public DateTime Jour { get; set; }

    public int? Bb { get; set; }

    public int IdCompagnie { get; set; }

    public string? Type { get; set; }

    public int? NbSiege { get; set; }

    public virtual Compagnie IdCompagnieNavigation { get; set; } = null!;

    public virtual ICollection<Vol> Vols { get; set; } = new List<Vol>();

    public virtual Aerodrome DestProvNavigation { get; set; } = null!;

    public virtual Aircraft ImmatriculationNavigation { get; set; } = null!;
}
