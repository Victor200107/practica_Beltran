using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public string? EMail { get; set; }

    public string? Telefono { get; set; }

    public string? NumeroPaquetes { get; set; }

    public string? FechaFactura { get; set; }

    public string? FechaVencimiento { get; set; }

    public string? PesoTotal { get; set; }

    public string? Factura1 { get; set; }

    public int? IdClientefk { get; set; }

    public int? IdEfacturaDetalleEnviofk { get; set; }

    public virtual ICollection<FacturaDetallePaquete> FacturaDetallePaquetes { get; } = new List<FacturaDetallePaquete>();

    public virtual Cliente? IdClientefkNavigation { get; set; }

    public virtual FacturaDetalleEnvio? IdEfacturaDetalleEnviofkNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; } = new List<Pago>();

    public virtual ICollection<PaqueteDetalle> PaqueteDetalles { get; } = new List<PaqueteDetalle>();
}
