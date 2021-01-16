using EstefaniasJeans.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstefaniasJeans.Data.Mapping
{
  public class MercaderiaMap : IEntityTypeConfiguration<Mercaderia>
  {
    public void Configure(EntityTypeBuilder<Mercaderia> builder)
    {
      builder
        .Property(x => x.Id_Mercaderia)
        .HasColumnName("Id");

      builder
        .HasKey(x => x.Id_Mercaderia);

      builder
        .Property(x => x.Nombre)
        .HasColumnType("VARCHAR(50)");

      builder
        .Property(x => x.Descripcion)
        .HasColumnType("VARCHAR(250)");

      builder
       .Property(x => x.Precio)
       .HasColumnType("Decimal(8,2)");

      builder.HasOne(x => x.Categoria)
        .WithMany(x => x.Mercaderia)
        .HasForeignKey(x => x.Id_Categoria);

      builder.HasOne(x => x.Persona)
       .WithMany(x => x.Mercaderia)
       .HasForeignKey(x => x.Id_Persona);
    }
  }
}
