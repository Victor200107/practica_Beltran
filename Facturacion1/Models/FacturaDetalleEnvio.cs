using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class FacturaDetalleEnvio
{
    public int IdFacturaDetalleEnvio { get; set; }

    public string? Estado { get; set; }

    public string? ValoresPago { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

    public virtual ICollection<Paquete> Paquetes { get; } = new List<Paquete>();
}
