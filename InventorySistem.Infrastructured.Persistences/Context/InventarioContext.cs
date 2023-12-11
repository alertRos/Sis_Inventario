using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using InventorySystem.Core.Domain.Entities;
using InventorySystem.Core.Domain.Common;

namespace InventorySystem.Infrastructured.Persistences.Context;

public partial class InventarioContext : DbContext
{

    public InventarioContext(DbContextOptions<InventarioContext> options)
        : base(options)
    {

    }
   
    public virtual DbSet<Categorias> Categoria { get; set; }

    public virtual DbSet<Marcas> Marcas { get; set; }

    public virtual DbSet<Negocios> Negocios { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedores> Proveedors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Representante> Representantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //      //  => optionsBuilder.UseSqlServer("server=JAVIERBELTRAN\\SQLEXPRESS01; database=Inventario; integrated security=true; TrustServerCertificate=True ");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorias>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3213E83F23713857");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Marcas>(entity =>
        {
            entity.ToTable("Marca");

            entity.HasKey(e => e.Id).HasName("PK_Marca");
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Negocios>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Negocio__3213E83F961B4818");

            entity.ToTable("Negocio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");

        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3213E83F97B632DC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AreaUbicacion)
                .HasColumnType("text")
                .HasColumnName("areaUbicacion");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCaducidad)
                .HasColumnType("date")
                .HasColumnName("fechaCaducidad");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e=>e.ImgUrl)    
                .IsUnicode(false)
                .HasColumnName("rutaImg");
            entity.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Productos_Categoria");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Productos_Marca");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Productos_Proveedor");


            entity.HasOne(d => d.Negocios).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdNegocio)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Productos_Negocio");
        });

        modelBuilder.Entity<Proveedores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3213E83F98014B45");

            entity.ToTable("Proveedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Direccion)
                .HasColumnType("text")
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FC82D7D5E");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasColumnName("password");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Nombre");
        });

        modelBuilder.Entity<Representante>(entity =>
        {
            entity.HasKey(r => r.Id).HasName("PK__Representante__3213E83F23713857");
            entity.ToTable("Representante");
            entity.Property(r => r.Id).HasColumnName("id");
            entity.Property(r => r.Nombre)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(r => r.Apellido)
            .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(r => r.Cedula)
            .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("cedula");
            entity.Property(r => r.Telefono)
            .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(r => r.IdNegocio).HasColumnName("idNegocio");
            entity.Property(r => r.IdUsuario).HasColumnName("idUsuario");
            entity.HasOne(r => r.Negocio)
            .WithMany(n => n.Representantes)
            .HasForeignKey(r => r.IdNegocio)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Representante_Negocio");
            entity.HasOne(r => r.Usuario)
            .WithMany(u => u.Representantes)
            .HasForeignKey(r => r.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Representante_Usuario");

        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
