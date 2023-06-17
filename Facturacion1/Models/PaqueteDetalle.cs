using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class PaqueteDetalle
{
    public int IdDato { get; set; }

    public string? Estado { get; set; }

    public string? ItemsClasificacion { get; set; }

    public string? PesoCaja { get; set; }

    public string? PesoIndividual { get; set; }

    public string? CostoItem { get; set; }

    public string? PrecioTotalItem { get; set; }

    public string? PesoTotal { get; set; }

    public string? FechaVencimiento { get; set; }

    public int? IdFacturafk { get; set; }

    public virtual Factura? IdFacturafkNavigation { get; set; }
}
