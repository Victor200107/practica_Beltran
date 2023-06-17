using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Estacion
{
    public int IdSucursal { get; set; }

    public string? Estado { get; set; }

    public string? FechaSalida { get; set; }

    public string? Ruc { get; set; }

    public int? IdPaisfk { get; set; }

    public virtual Pai? IdPaisfkNavigation { get; set; }

    public virtual ICollection<Oficina> Oficinas { get; } = new List<Oficina>();
}
