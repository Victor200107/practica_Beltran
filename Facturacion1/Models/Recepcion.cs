using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Recepcion
{
    public int IdRecepcion { get; set; }

    public string? Estado { get; set; }

    public string? FechaRecepcion { get; set; }

    public virtual ICollection<Paquete> Paquetes { get; } = new List<Paquete>();
}
