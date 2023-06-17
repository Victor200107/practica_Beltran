using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Empresa
{
    public int IdRuc { get; set; }

    public string? Estado { get; set; }

    public string? ValoresPago { get; set; }

    public string? NombreComercial { get; set; }

    public string? RazonSocial { get; set; }
}
