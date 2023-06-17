using System;
using System.Collections.Generic;

namespace Facturacion1.Models;

public partial class Pai
{
    public int IdPais { get; set; }

    public string? Estado { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Ciudad> Ciudads { get; } = new List<Ciudad>();

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Estacion> Estacions { get; } = new List<Estacion>();
}
