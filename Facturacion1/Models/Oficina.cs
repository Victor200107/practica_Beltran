using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Oficina
{
    public int IdOficina { get; set; }

    public string? Estado { get; set; }

    public string? TipoGestion { get; set; }

    public string? FechaLlegada { get; set; }

    public int? IdSucursalfk { get; set; }

    public virtual Estacion? IdSucursalfkNavigation { get; set; }
}
