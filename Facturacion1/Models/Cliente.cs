using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Cedula { get; set; }

    public string? Direccion { get; set; }

    public string? Ruc { get; set; }

    public string? RefDireccion { get; set; }

    public string? CodigoPostal { get; set; }

    public string? Telefono { get; set; }

    public int? IdPaisfk { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

    public virtual Pai? IdPaisfkNavigation { get; set; }

    public virtual ICollection<Paquete> Paquetes { get; } = new List<Paquete>();
}
