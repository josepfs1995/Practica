using EstefaniasJeans.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstefaniasJeans.Data.Mapping
{
  public class PedidoDetalleMap : IEntityTypeConfiguration<PedidoDetalle>
  {
    public void Configure(EntityTypeBuilder<PedidoDetalle> builder)
    {
      builder
        .Property(x => x.Id_PedidoDetalle)
        .HasColumnName("Id");

      builder
        .HasKey(x => x.Id_PedidoDetalle);

      builder
      .Property(x => x.Precio)
      .HasColumnType("Decimal(8,2)");

      builder
       .Property(x => x.PrecioTotal)
       .HasColumnType("Decimal(8,2)");

      builder.HasOne(x => x.Pedido)
        .WithMany(x => x.PedidoDetalle)
        .HasForeignKey(x=>x.Id_Pedido);

      builder.HasOne(x => x.Mercaderia)
       .WithMany(x => x.PedidoDetalle)
      .HasForeignKey(x => x.Id_Mercaderia);

    }
  }
}
