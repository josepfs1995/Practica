using EstefaniasJeans.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstefaniasJeans.Data.Mapping
{
  public class PedidoMap : IEntityTypeConfiguration<Pedido>
  {
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
      builder
        .Property(x => x.Id_Pedido)
        .HasColumnName("Id");

      builder
        .HasKey(x => x.Id_Pedido);

      builder
      .Property(x => x.Descripcion)
      .HasColumnType("Varchar(250)");

      builder
       .Property(x => x.PrecioTotal)
       .HasColumnType("Decimal(8,2)");

       builder.HasOne(x=>x.Persona)
       .WithMany(x=>x.Pedido)
       .HasForeignKey(x=>x.Id_Persona);

    }
  }
}
