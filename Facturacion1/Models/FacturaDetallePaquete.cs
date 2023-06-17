using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class FacturaDetallePaquete
{
    public int IdFacturaDetallePaquete { get; set; }

    public string? Estado { get; set; }

    public string? ValoresPago { get; set; }

    public int? IdFacturafk { get; set; }

    public virtual Factura? IdFacturafkNavigation { get; set; }
}
