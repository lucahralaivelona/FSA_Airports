using System;
using System.Collections.Generic;

namespace FSAproject.Models;

public partial class Aerodrome
{
    public string CodeIata { get; set; } = null!;

    public string CodeOaci { get; set; } = null!;

    public string Aeroport { get; set; } = null!;

    public int IdGestionnaireAerodrome { get; set; }

    public string Tarif { get; set; }

    public virtual GestionnaireAerodrome? IdGestionnaireAerodromeNavigation { get; set; } 


    public virtual ICollection<Vol> Vols { get; set; } = new List<Vol>();
}
