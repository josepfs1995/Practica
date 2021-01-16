using EstefaniasJeans.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace EstefaniasJeans.Data.Seed
{
  public static class EstefaniasJeansSeed
  {
    public static void Seed(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Categoria>()
        .HasData(
          new Categoria
          {
            Id_Categoria = new Guid("8b2b3d2b-5eb4-460a-ac44-37f6c081bdd2"),
            Nombre = "Pantalón"
          },
          new Categoria
          {
            Id_Categoria = new Guid("da623463-9123-4890-9193-350172843fb3"),
            Nombre = "Jumpers"
          },
          new Categoria
          {
            Id_Categoria = new Guid("7f5ba8d6-6af3-438e-8c19-1e45215b756b"),
            Nombre = "Shorts"
          },
          new Categoria
          {
            Id_Categoria = new Guid("10deaf97-b2ad-4a52-8ad2-511082d4049c"),
            Nombre = "Faldas"
          },
          new Categoria
          {
            Id_Categoria = new Guid("fbe611c7-259d-4a2b-9b81-f0174a74b8ae"),
            Nombre = "Toreros"
          }
      );
    }
    public static void SeedIdentity(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<IdentityRole>()
        .HasData(
          new IdentityRole{
            Name = "Administrador",
            NormalizedName = "Administrador"
          },
          new IdentityRole{
            Name = "Paciente",
            NormalizedName = "Paciente"
          }
      );
    }
  }
}
