using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FSAproject.Models;

public partial class GestionnaireAerodrome
{
    public int IdGestionnaireAerodrome { get; set; }

    public string? GestionnaireAerodrome1 { get; set; }

    public string? ContactAdresse { get; set; }

    public virtual ICollection<Aerodrome> Aerodromes { get; set; } = new List<Aerodrome>();
    
    
    public virtual ICollection<Utilisateur> Utilisateurs { get; set; } = new List<Utilisateur>();
}
