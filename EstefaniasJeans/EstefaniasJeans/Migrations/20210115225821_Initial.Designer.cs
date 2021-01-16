﻿// <auto-generated />
using System;
using EstefaniasJeans.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EstefaniasJeans.Migrations
{
    [DbContext(typeof(EstefaniasJeansContext))]
    [Migration("20210115225821_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("EstefaniasJeans.Data.Model.Categoria", b =>
                {
                    b.Property<Guid>("Id_Categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Nombre")
                        .HasColumnType("Varchar(30)");

                    b.HasKey("Id_Categoria");

                    b.ToTable("Categoria");

                    b.HasData(
                        new
                        {
                            Id_Categoria = new Guid("8b2b3d2b-5eb4-460a-ac44-37f6c081bdd2"),
                            Nombre = "Pantalón"
                        },
                        new
                        {
                            Id_Categoria = new Guid("da623463-9123-4890-9193-350172843fb3"),
                            Nombre = "Jumpers"
                        },
                        new
                        {
                            Id_Categoria = new Guid("7f5ba8d6-6af3-438e-8c19-1e45215b756b"),
                            Nombre = "Shorts"
                        },
                        new
                        {
                            Id_Categoria = new Guid("10deaf97-b2ad-4a52-8ad2-511082d4049c"),
                            Nombre = "Faldas"
                        },
                        new
                        {
                            Id_Categoria = new Guid("fbe611c7-259d-4a2b-9b81-f0174a74b8ae"),
                            Nombre = "Toreros"
                        });
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.Mercaderia", b =>
                {
                    b.Property<Guid>("Id_Mercaderia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Descripcion")
                        .HasColumnType("VARCHAR(250)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_Categoria")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Id_Persona")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("Decimal(8,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("StockRestante")
                        .HasColumnType("int");

                    b.HasKey("Id_Mercaderia");

                    b.HasIndex("Id_Categoria");

                    b.HasIndex("Id_Persona");

                    b.ToTable("Mercaderias");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.MercaderiaFoto", b =>
                {
                    b.Property<Guid>("Id_MercaderiaFoto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_Mercaderia")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .HasColumnType("VARCHAR(250)");

                    b.HasKey("Id_MercaderiaFoto");

                    b.HasIndex("Id_Mercaderia");

                    b.ToTable("MercaderiaFotos");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.Pedido", b =>
                {
                    b.Property<Guid>("Id_Pedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Descripcion")
                        .HasColumnType("Varchar(250)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_Persona")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PrecioTotal")
                        .HasColumnType("Decimal(8,2)");

                    b.HasKey("Id_Pedido");

                    b.HasIndex("Id_Persona");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.PedidoDetalle", b =>
                {
                    b.Property<Guid>("Id_PedidoDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<Guid>("Id_Mercaderia")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Pedido")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Precio")
                        .HasColumnType("Decimal(8,2)");

                    b.Property<decimal>("PrecioTotal")
                        .HasColumnType("Decimal(8,2)");

                    b.HasKey("Id_PedidoDetalle");

                    b.HasIndex("Id_Mercaderia");

                    b.HasIndex("Id_Pedido");

                    b.ToTable("PedidoDetalles");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.Persona", b =>
                {
                    b.Property<Guid>("Id_Persona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Apellidos")
                        .HasColumnType("Varchar(70)");

                    b.Property<string>("Celular")
                        .HasColumnType("Varchar(12)");

                    b.Property<string>("Direccion1")
                        .HasColumnType("NVarchar(250)");

                    b.Property<string>("Direccion2")
                        .HasColumnType("NVarchar(250)");

                    b.Property<string>("Documento")
                        .HasColumnType("Varchar(12)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .HasColumnType("Varchar(70)");

                    b.HasKey("Id_Persona");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.Mercaderia", b =>
                {
                    b.HasOne("EstefaniasJeans.Data.Model.Categoria", "Categoria")
                        .WithMany("Mercaderia")
                        .HasForeignKey("Id_Categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EstefaniasJeans.Data.Model.Persona", "Persona")
                        .WithMany("Mercaderia")
                        .HasForeignKey("Id_Persona");

                    b.Navigation("Categoria");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.MercaderiaFoto", b =>
                {
                    b.HasOne("EstefaniasJeans.Data.Model.Mercaderia", "Mercaderia")
                        .WithMany("MercaderiaFoto")
                        .HasForeignKey("Id_Mercaderia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mercaderia");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.Pedido", b =>
                {
                    b.HasOne("EstefaniasJeans.Data.Model.Persona", "Persona")
                        .WithMany("Pedido")
                        .HasForeignKey("Id_Persona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.PedidoDetalle", b =>
                {
                    b.HasOne("EstefaniasJeans.Data.Model.Mercaderia", "Mercaderia")
                        .WithMany("PedidoDetalle")
                        .HasForeignKey("Id_Mercaderia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EstefaniasJeans.Data.Model.Pedido", "Pedido")
                        .WithMany("PedidoDetalle")
                        .HasForeignKey("Id_Pedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mercaderia");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.Categoria", b =>
                {
                    b.Navigation("Mercaderia");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.Mercaderia", b =>
                {
                    b.Navigation("MercaderiaFoto");

                    b.Navigation("PedidoDetalle");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.Pedido", b =>
                {
                    b.Navigation("PedidoDetalle");
                });

            modelBuilder.Entity("EstefaniasJeans.Data.Model.Persona", b =>
                {
                    b.Navigation("Mercaderia");

                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
