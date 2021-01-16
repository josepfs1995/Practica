using EstefaniasJeans.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstefaniasJeans.Data.Mapping
{
  public class MercaderiaFotoMap : IEntityTypeConfiguration<MercaderiaFoto>
  {
    public void Configure(EntityTypeBuilder<MercaderiaFoto> builder)
    {
      builder
        .Property(x => x.Id_MercaderiaFoto)
        .HasColumnName("Id")
        .ValueGeneratedOnAdd();

      builder
        .HasKey(x => x.Id_MercaderiaFoto);

      builder
        .Property(x => x.Nombre)
        .HasColumnType("VARCHAR(250)");

      builder.HasOne(x => x.Mercaderia)
        .WithMany(x => x.MercaderiaFoto)
        .HasForeignKey(x=>x.Id_Mercaderia);
    }
  }
}
