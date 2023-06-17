using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Ciudad
{
    public int IdCiudad { get; set; }

    public string? Estado { get; set; }

    public string? Nombre { get; set; }

    public int? IdPaisfk { get; set; }

    public virtual Pai? IdPaisfkNavigation { get; set; }

    public virtual ICollection<Parroquium> Parroquia { get; } = new List<Parroquium>();
}
