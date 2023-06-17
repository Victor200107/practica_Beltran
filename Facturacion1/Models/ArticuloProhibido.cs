using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class ArticuloProhibido
{
    public int IdArticuloNoAdmitido { get; set; }

    public string? Nombre { get; set; }

    public string? Estado { get; set; }
}
