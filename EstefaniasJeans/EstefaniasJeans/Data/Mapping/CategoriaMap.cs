using EstefaniasJeans.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstefaniasJeans.Data.Mapping
{
  public class CategoriaMap : IEntityTypeConfiguration<Categoria>
  {
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
      builder
        .Property(x => x.Id_Categoria)
        .HasColumnName("Id");

      builder.HasKey(x => x.Id_Categoria);

      builder
        .Property(x => x.Nombre)
        .HasColumnType("Varchar(30)");
    }
  }
}
