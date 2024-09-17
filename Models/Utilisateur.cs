using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FSAproject.Models;

public partial class Utilisateur
{
    public int IdUtilisateur { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public int IdGestionnaireAerodrome { get; set; } 

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;





    public virtual GestionnaireAerodrome? IdGestionnaireAerodromeNavigation { get; } = null;
}
