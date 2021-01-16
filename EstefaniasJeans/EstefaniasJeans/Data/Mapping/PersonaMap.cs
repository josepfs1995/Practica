using EstefaniasJeans.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstefaniasJeans.Data.Mapping
{
  public class PersonaMap : IEntityTypeConfiguration<Persona>
  {
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
      builder.Property(x => x.Id_Persona)
       .HasColumnName("Id");

      builder
        .HasKey(x => x.Id_Persona);

      builder
      .Property(x => x.Nombres)
      .HasColumnType("Varchar(70)");

      builder
      .Property(x => x.Apellidos)
      .HasColumnType("Varchar(70)");

      builder
      .Property(x => x.Direccion1)
      .HasColumnType("NVarchar(250)");

      builder
      .Property(x => x.Direccion2)
      .HasColumnType("NVarchar(250)");

      builder
      .Property(x => x.Documento)
      .HasColumnType("Varchar(12)");

      builder
      .Property(x => x.Celular)
      .HasColumnType("Varchar(12)");
   
    }
  }
}
