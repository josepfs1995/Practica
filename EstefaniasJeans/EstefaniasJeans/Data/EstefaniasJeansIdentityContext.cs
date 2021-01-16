using EstefaniasJeans.Data.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EstefaniasJeans.Data
{
  public class EstefaniasJeansIdentityContext : IdentityDbContext
  {
    public EstefaniasJeansIdentityContext(DbContextOptions<EstefaniasJeansIdentityContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.SeedIdentity();
      base.OnModelCreating(builder);
    }
  }
}
