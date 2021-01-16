using EstefaniasJeans.Configuration;
using EstefaniasJeans.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EstefaniasJeans
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddIdentityConfigure(Configuration);
      services.AddDbContext<EstefaniasJeansContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ConBD")));
      services.AddMediatR(typeof(Startup));
      services.AddInjectionDependencyConfigure();
      services.AddAutoMapperConfigure();

      services.AddAuthenticationConfigure(Configuration);

      services.AddMvc()
        .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

      services.AddSwaggerConfigure();

      services.AddCors(option =>
      {
        option.AddPolicy("TODOS", policy => policy.WithOrigins("http://localhost:4200").WithMethods("POST", "GET", "DELETE", "PUT").AllowAnyHeader());
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      

      app.UseSwaggerConfigure();

      app.UseRouting();

      app.UseAuthenticationConfigure();

      app.UseCors("TODOS");

      app.UseStaticFiles();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
