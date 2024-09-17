using System;
using System.Collections.Generic;

namespace FSAproject.Models;

public partial class Vol
{
    public int idVol { get; set; }

    public string Immatriculation { get; set; }
    public string NumeroVol { get; set; }

    public string Resau { get; set; } = null!;
    public string Local { get; set; } = null!;

        
    public string HeurePiste { get; set; }

    public string HeureBloc { get; set; }

    public string DestProv { get; set; } = null!;

    public int? PaxC { get; set; }

    public int? PaxY { get; set; }

    public int Total { get; set; }

    public string Immd { get; set; }

    public short Annee { get; set; }

    public string Mois { get; set; }

    public string Jour { get; set; }

    public int? Bb { get; set; }

    public virtual Aerodrome? DestProvNavigation { get; set; } = null;

    public virtual Aircraft? ImmatriculationNavigation { get; set; } = null;
}
