using EstefaniasJeans.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EstefaniasJeans.Configuration
{
  public static class IdentityConfigure
  {
    public static void AddIdentityConfigure(this IServiceCollection service, IConfiguration configuration)
    {
      service.AddDbContext<EstefaniasJeansIdentityContext>(option => option.UseSqlServer(configuration.GetConnectionString("ConBD")));

      service.AddDefaultIdentity<IdentityUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<EstefaniasJeansIdentityContext>()
        .AddDefaultTokenProviders();

    }
  }
}
