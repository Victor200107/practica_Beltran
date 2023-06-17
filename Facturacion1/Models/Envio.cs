using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Envio
{
    public int IdEnvio { get; set; }

    public string? Estado { get; set; }

    public string? FechaLlegada { get; set; }

    public string? FechaPartida { get; set; }

    public virtual ICollection<Paquete> Paquetes { get; } = new List<Paquete>();
}
