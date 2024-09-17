using System;
using System.Collections.Generic;

namespace FSAproject.Models;

public partial class Compagnie
{
    public int IdCompagnie { get; set; }

    public string? Adresse { get; set; }

    public string? Email { get; set; }

    public string Nom { get; set; } = null!;

    public string? InitialCompagnie { get; set; }

    public virtual ICollection<Aircraft> Aircraft { get; set; } = new List<Aircraft>();
}
