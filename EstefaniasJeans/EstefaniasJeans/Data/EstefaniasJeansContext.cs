using EstefaniasJeans.Data.Model;
using EstefaniasJeans.Data.Seed;
using EstefaniasJeans.Data.UoW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EstefaniasJeans.Data
{
  public class EstefaniasJeansContext:DbContext, IUnitOfWork, IDisposable
  {
    public DbSet<Categoria> Categoria { get; set; }
    public DbSet<Mercaderia> Mercaderias { get; set; }
    public DbSet<MercaderiaFoto> MercaderiaFotos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoDetalle> PedidoDetalles { get; set; }
    public EstefaniasJeansContext(DbContextOptions<EstefaniasJeansContext> options):base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
      modelBuilder.Seed();
      base.OnModelCreating(modelBuilder);
    }
    public async Task<bool> Save()
    {
      return await SaveChangesAsync() > 0;
    }
  }
}
