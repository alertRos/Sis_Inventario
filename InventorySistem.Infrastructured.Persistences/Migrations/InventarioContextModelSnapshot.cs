﻿// <auto-generated />
using System;
using InventorySystem.Infrastructured.Persistences.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InventorySystem.Infrastructured.Persistences.Migrations
{
    [DbContext(typeof(InventarioContext))]
    partial class InventarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Categorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PK__Categori__3213E83F23713857");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Marcas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telefono");

                    b.HasKey("Id")
                        .HasName("PK_Marca");

                    b.ToTable("Marca", (string)null);
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Negocios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("direccion");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telefono");

                    b.HasKey("Id")
                        .HasName("PK__Negocio__3213E83F961B4818");

                    b.ToTable("Negocio", (string)null);
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AreaUbicacion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("areaUbicacion");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("descripcion");

                    b.Property<DateTime?>("FechaCaducidad")
                        .HasColumnType("date")
                        .HasColumnName("fechaCaducidad");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int")
                        .HasColumnName("idCategoria");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int")
                        .HasColumnName("idMarca");

                    b.Property<int>("IdNegocio")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int")
                        .HasColumnName("idProveedor");

                    b.Property<string>("ImgUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("rutaImg");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("nombre");

                    b.Property<decimal>("Precio")
                        .HasColumnType("money")
                        .HasColumnName("precio");

                    b.Property<int>("Stock")
                        .HasColumnType("int")
                        .HasColumnName("stock");

                    b.HasKey("Id")
                        .HasName("PK__Producto__3213E83F97B632DC");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdMarca");

                    b.HasIndex("IdNegocio");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Proveedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .HasColumnType("text")
                        .HasColumnName("direccion");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("telefono");

                    b.HasKey("Id")
                        .HasName("PK__Proveedo__3213E83F98014B45");

                    b.ToTable("Proveedor", (string)null);
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Representante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("apellido");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("cedula");

                    b.Property<int>("IdNegocio")
                        .HasColumnType("int")
                        .HasColumnName("idNegocio");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int")
                        .HasColumnName("idUsuario");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("nombre");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(70)
                        .IsUnicode(false)
                        .HasColumnType("varchar(70)")
                        .HasColumnName("telefono");

                    b.HasKey("Id")
                        .HasName("PK__Representante__3213E83F23713857");

                    b.HasIndex("IdNegocio");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Representante", (string)null);
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Nombre");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Usuario__3213E83FC82D7D5E");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Producto", b =>
                {
                    b.HasOne("InventorySystem.Core.Domain.Entities.Categorias", "IdCategoriaNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Productos_Categoria");

                    b.HasOne("InventorySystem.Core.Domain.Entities.Marcas", "IdMarcaNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("IdMarca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Productos_Marca");

                    b.HasOne("InventorySystem.Core.Domain.Entities.Negocios", "Negocios")
                        .WithMany("Productos")
                        .HasForeignKey("IdNegocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Productos_Negocio");

                    b.HasOne("InventorySystem.Core.Domain.Entities.Proveedores", "IdProveedorNavigation")
                        .WithMany("Productos")
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Productos_Proveedor");

                    b.Navigation("IdCategoriaNavigation");

                    b.Navigation("IdMarcaNavigation");

                    b.Navigation("IdProveedorNavigation");

                    b.Navigation("Negocios");
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Representante", b =>
                {
                    b.HasOne("InventorySystem.Core.Domain.Entities.Negocios", "Negocio")
                        .WithMany("Representantes")
                        .HasForeignKey("IdNegocio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Representante_Negocio");

                    b.HasOne("InventorySystem.Core.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Representantes")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Representante_Usuario");

                    b.Navigation("Negocio");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Categorias", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Marcas", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Negocios", b =>
                {
                    b.Navigation("Productos");

                    b.Navigation("Representantes");
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Proveedores", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("InventorySystem.Core.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Representantes");
                });
#pragma warning restore 612, 618
        }
    }
}
