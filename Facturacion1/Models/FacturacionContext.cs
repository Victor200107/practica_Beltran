using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Facturacion1.Models;

public partial class FacturacionContext : DbContext
{
    public FacturacionContext()
    {
    }

    public FacturacionContext(DbContextOptions<FacturacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArticuloProhibido> ArticuloProhibidos { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Estacion> Estacions { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FacturaDetalleEnvio> FacturaDetalleEnvios { get; set; }

    public virtual DbSet<FacturaDetallePaquete> FacturaDetallePaquetes { get; set; }

    public virtual DbSet<Oficina> Oficinas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Paquete> Paquetes { get; set; }

    public virtual DbSet<PaqueteDetalle> PaqueteDetalles { get; set; }

    public virtual DbSet<Parroquium> Parroquia { get; set; }

    public virtual DbSet<Recepcion> Recepcions { get; set; }

    public virtual DbSet<TipoMaterial> TipoMaterials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL("Name=ConnectionStrings:Data");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArticuloProhibido>(entity =>
        {
            entity.HasKey(e => e.IdArticuloNoAdmitido).HasName("PRIMARY");

            entity.ToTable("articulo_prohibido");

            entity.Property(e => e.IdArticuloNoAdmitido).HasColumnName("id_Articulo_No_Admitido");
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("PRIMARY");

            entity.ToTable("ciudad");

            entity.HasIndex(e => e.IdPaisfk, "IdPaisfk");

            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdPaisfkNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdPaisfk)
                .HasConstraintName("ciudad_ibfk_1");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.HasIndex(e => e.IdPaisfk, "IdPaisfk");

            entity.Property(e => e.Cedula)
                .HasMaxLength(100)
                .HasColumnName("cedula");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(80)
                .HasColumnName("Codigo_Postal");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion");
            entity.Property(e => e.RefDireccion)
                .HasMaxLength(100)
                .HasColumnName("Ref_Direccion");
            entity.Property(e => e.Ruc)
                .HasMaxLength(80)
                .HasColumnName("ruc");
            entity.Property(e => e.Telefono).HasMaxLength(40);

            entity.HasOne(d => d.IdPaisfkNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdPaisfk)
                .HasConstraintName("cliente_ibfk_1");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdRuc).HasName("PRIMARY");

            entity.ToTable("empresa");

            entity.Property(e => e.IdRuc).HasColumnName("id_RUC");
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.NombreComercial)
                .HasMaxLength(100)
                .HasColumnName("Nombre_Comercial");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(100)
                .HasColumnName("Razon_Social");
            entity.Property(e => e.ValoresPago)
                .HasMaxLength(100)
                .HasColumnName("Valores_pago");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.IdEnvio).HasName("PRIMARY");

            entity.ToTable("envio");

            entity.Property(e => e.IdEnvio).HasColumnName("id_Envio");
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.FechaLlegada)
                .HasMaxLength(100)
                .HasColumnName("Fecha_LLegada");
            entity.Property(e => e.FechaPartida)
                .HasMaxLength(100)
                .HasColumnName("Fecha_Partida");
        });

        modelBuilder.Entity<Estacion>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PRIMARY");

            entity.ToTable("estacion");

            entity.HasIndex(e => e.IdPaisfk, "IdPaisfk");

            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.FechaSalida)
                .HasMaxLength(100)
                .HasColumnName("Fecha_Salida");
            entity.Property(e => e.Ruc)
                .HasMaxLength(80)
                .HasColumnName("ruc");

            entity.HasOne(d => d.IdPaisfkNavigation).WithMany(p => p.Estacions)
                .HasForeignKey(d => d.IdPaisfk)
                .HasConstraintName("estacion_ibfk_1");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PRIMARY");

            entity.ToTable("factura");

            entity.HasIndex(e => e.IdClientefk, "IdClientefk");

            entity.HasIndex(e => e.IdEfacturaDetalleEnviofk, "IdEFactura_Detalle_Enviofk");

            entity.Property(e => e.EMail)
                .HasMaxLength(100)
                .HasColumnName("E_Mail");
            entity.Property(e => e.Factura1)
                .HasMaxLength(100)
                .HasColumnName("Factura");
            entity.Property(e => e.FechaFactura)
                .HasMaxLength(100)
                .HasColumnName("Fecha_Factura");
            entity.Property(e => e.FechaVencimiento)
                .HasMaxLength(100)
                .HasColumnName("Fecha_Vencimiento");
            entity.Property(e => e.IdEfacturaDetalleEnviofk).HasColumnName("IdEFactura_Detalle_Enviofk");
            entity.Property(e => e.NumeroPaquetes)
                .HasMaxLength(100)
                .HasColumnName("Numero_Paquetes");
            entity.Property(e => e.PesoTotal)
                .HasMaxLength(100)
                .HasColumnName("Peso_Total");
            entity.Property(e => e.Telefono).HasMaxLength(100);

            entity.HasOne(d => d.IdClientefkNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdClientefk)
                .HasConstraintName("factura_ibfk_1");

            entity.HasOne(d => d.IdEfacturaDetalleEnviofkNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdEfacturaDetalleEnviofk)
                .HasConstraintName("factura_ibfk_2");
        });

        modelBuilder.Entity<FacturaDetalleEnvio>(entity =>
        {
            entity.HasKey(e => e.IdFacturaDetalleEnvio).HasName("PRIMARY");

            entity.ToTable("factura_detalle_envio");

            entity.Property(e => e.IdFacturaDetalleEnvio).HasColumnName("idFactura_Detalle_Envio");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .HasColumnName("estado");
            entity.Property(e => e.ValoresPago)
                .HasMaxLength(100)
                .HasColumnName("Valores_pago");
        });

        modelBuilder.Entity<FacturaDetallePaquete>(entity =>
        {
            entity.HasKey(e => e.IdFacturaDetallePaquete).HasName("PRIMARY");

            entity.ToTable("factura_detalle_paquete");

            entity.HasIndex(e => e.IdFacturafk, "IdFacturafk");

            entity.Property(e => e.IdFacturaDetallePaquete).HasColumnName("IdFactura_Detalle_Paquete");
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.ValoresPago)
                .HasMaxLength(100)
                .HasColumnName("Valores_Pago");

            entity.HasOne(d => d.IdFacturafkNavigation).WithMany(p => p.FacturaDetallePaquetes)
                .HasForeignKey(d => d.IdFacturafk)
                .HasConstraintName("factura_detalle_paquete_ibfk_1");
        });

        modelBuilder.Entity<Oficina>(entity =>
        {
            entity.HasKey(e => e.IdOficina).HasName("PRIMARY");

            entity.ToTable("oficina");

            entity.HasIndex(e => e.IdSucursalfk, "IdSucursalfk");

            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.FechaLlegada)
                .HasMaxLength(80)
                .HasColumnName("Fecha_LLegada");
            entity.Property(e => e.TipoGestion)
                .HasMaxLength(100)
                .HasColumnName("Tipo_Gestion");

            entity.HasOne(d => d.IdSucursalfkNavigation).WithMany(p => p.Oficinas)
                .HasForeignKey(d => d.IdSucursalfk)
                .HasConstraintName("oficina_ibfk_1");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PRIMARY");

            entity.ToTable("pago");

            entity.HasIndex(e => e.IdFacturafk, "IdFacturafk");

            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.FechaVencimiento)
                .HasMaxLength(100)
                .HasColumnName("Fecha_Vencimiento");
            entity.Property(e => e.ValoresPago)
                .HasMaxLength(100)
                .HasColumnName("Valores_Pago");

            entity.HasOne(d => d.IdFacturafkNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdFacturafk)
                .HasConstraintName("pago_ibfk_1");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PRIMARY");

            entity.ToTable("pais");

            entity.Property(e => e.IdPais).HasColumnName("id_Pais");
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.IdPaquete).HasName("PRIMARY");

            entity.ToTable("paquete");

            entity.HasIndex(e => e.IdClientefk, "IdClientefk");

            entity.HasIndex(e => e.IdEfacturaDetalleEnviofk, "IdEFactura_Detalle_Enviofk");

            entity.HasIndex(e => e.IdEnviofk, "IdEnviofk");

            entity.HasIndex(e => e.IdRecepcionfk, "IdRecepcionfk");

            entity.Property(e => e.CodigoBarras)
                .HasMaxLength(100)
                .HasColumnName("Codigo_Barras");
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.FechaLlegada)
                .HasMaxLength(100)
                .HasColumnName("Fecha_LLegada");
            entity.Property(e => e.FechaPartida)
                .HasMaxLength(100)
                .HasColumnName("Fecha_Partida");
            entity.Property(e => e.FechaRecepcion)
                .HasMaxLength(100)
                .HasColumnName("Fecha_Recepcion");
            entity.Property(e => e.IdEfacturaDetalleEnviofk).HasColumnName("IdEFactura_Detalle_Enviofk");
            entity.Property(e => e.PinSalida)
                .HasMaxLength(100)
                .HasColumnName("Pin_Salida");

            entity.HasOne(d => d.IdClientefkNavigation).WithMany(p => p.Paquetes)
                .HasForeignKey(d => d.IdClientefk)
                .HasConstraintName("paquete_ibfk_1");

            entity.HasOne(d => d.IdEfacturaDetalleEnviofkNavigation).WithMany(p => p.Paquetes)
                .HasForeignKey(d => d.IdEfacturaDetalleEnviofk)
                .HasConstraintName("paquete_ibfk_4");

            entity.HasOne(d => d.IdEnviofkNavigation).WithMany(p => p.Paquetes)
                .HasForeignKey(d => d.IdEnviofk)
                .HasConstraintName("paquete_ibfk_2");

            entity.HasOne(d => d.IdRecepcionfkNavigation).WithMany(p => p.Paquetes)
                .HasForeignKey(d => d.IdRecepcionfk)
                .HasConstraintName("paquete_ibfk_3");
        });

        modelBuilder.Entity<PaqueteDetalle>(entity =>
        {
            entity.HasKey(e => e.IdDato).HasName("PRIMARY");

            entity.ToTable("paquete_detalle");

            entity.HasIndex(e => e.IdFacturafk, "IdFacturafk");

            entity.Property(e => e.CostoItem)
                .HasMaxLength(100)
                .HasColumnName("Costo_Item");
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.FechaVencimiento)
                .HasMaxLength(100)
                .HasColumnName("Fecha_Vencimiento");
            entity.Property(e => e.ItemsClasificacion)
                .HasMaxLength(100)
                .HasColumnName("Items_Clasificacion");
            entity.Property(e => e.PesoCaja)
                .HasMaxLength(100)
                .HasColumnName("Peso_Caja");
            entity.Property(e => e.PesoIndividual)
                .HasMaxLength(100)
                .HasColumnName("Peso_Individual");
            entity.Property(e => e.PesoTotal)
                .HasMaxLength(100)
                .HasColumnName("Peso_Total");
            entity.Property(e => e.PrecioTotalItem)
                .HasMaxLength(100)
                .HasColumnName("Precio_Total_Item");

            entity.HasOne(d => d.IdFacturafkNavigation).WithMany(p => p.PaqueteDetalles)
                .HasForeignKey(d => d.IdFacturafk)
                .HasConstraintName("paquete_detalle_ibfk_1");
        });

        modelBuilder.Entity<Parroquium>(entity =>
        {
            entity.HasKey(e => e.IdParroquia).HasName("PRIMARY");

            entity.ToTable("parroquia");

            entity.HasIndex(e => e.IdCiudadfk, "IdCiudadfk");

            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdCiudadfkNavigation).WithMany(p => p.Parroquia)
                .HasForeignKey(d => d.IdCiudadfk)
                .HasConstraintName("parroquia_ibfk_1");
        });

        modelBuilder.Entity<Recepcion>(entity =>
        {
            entity.HasKey(e => e.IdRecepcion).HasName("PRIMARY");

            entity.ToTable("recepcion");

            entity.Property(e => e.IdRecepcion).HasColumnName("id_Recepcion");
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.FechaRecepcion)
                .HasMaxLength(100)
                .HasColumnName("Fecha_Recepcion");
        });

        modelBuilder.Entity<TipoMaterial>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("PRIMARY");

            entity.ToTable("tipo_material");

            entity.Property(e => e.IdMaterial).HasColumnName("id_Material");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
