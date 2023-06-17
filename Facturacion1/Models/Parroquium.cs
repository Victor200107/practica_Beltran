using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Parroquium
{
    public int IdParroquia { get; set; }

    public string? Estado { get; set; }

    public string? Nombre { get; set; }

    public int? IdCiudadfk { get; set; }

    public virtual Ciudad? IdCiudadfkNavigation { get; set; }
}
