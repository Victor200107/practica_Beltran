using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Paquete
{
    public int IdPaquete { get; set; }

    public string? Estado { get; set; }

    public string? CodigoBarras { get; set; }

    public string? PinSalida { get; set; }

    public string? FechaPartida { get; set; }

    public string? FechaLlegada { get; set; }

    public string? FechaRecepcion { get; set; }

    public int? IdClientefk { get; set; }

    public int? IdEnviofk { get; set; }

    public int? IdRecepcionfk { get; set; }

    public int? IdDatofk { get; set; }

    public int? IdEfacturaDetalleEnviofk { get; set; }

    public virtual Cliente? IdClientefkNavigation { get; set; }

    public virtual FacturaDetalleEnvio? IdEfacturaDetalleEnviofkNavigation { get; set; }

    public virtual Envio? IdEnviofkNavigation { get; set; }

    public virtual Recepcion? IdRecepcionfkNavigation { get; set; }
}
