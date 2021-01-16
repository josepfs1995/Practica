using EstefaniasJeans.Application.Commands;
using EstefaniasJeans.Application.Commands.MercaderiaCommands;
using EstefaniasJeans.Application.Commands.PedidoCommands;
using EstefaniasJeans.Application.Commands.UsuarioCommands;
using EstefaniasJeans.Data.Model;
using EstefaniasJeans.Data.Repository;
using EstefaniasJeans.Extensions;
using EstefaniasJeans.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EstefaniasJeans.Configuration
{
  public static class InjectionDependencyConfigure
  {
    public static void AddInjectionDependencyConfigure(this IServiceCollection services)
    {
      //services.AddSingleton<IHttpContextAccessor>();
      services.AddScoped<IFileManagment, FileManagment>();
      services.AddScoped<IMercaderiaRepository, MercaderiaRepository>();
      services.AddScoped<ICategoriaRepository, CategoriaRepository>();
      services.AddScoped<IPedidoRepository, PedidoRepository>();
      services.AddScoped<IPersonaRepository, PersonaRepository>();

      services.AddScoped<IRequestHandler<CrearMercaderiaCommand, ResponseCommand<Mercaderia>>, MercaderiaCommandHandler>();
      services.AddScoped<IRequestHandler<CrearPedidoCommand,  ResponseCommand<Pedido>>, PedidoCommandHandler>();
      services.AddScoped<IRequestHandler<RegistrarUsuarioCommand, ResponseCommand<IdentityUser>>, UsuarioCommandHandler>();
      services.AddScoped<IRequestHandler<LoginUsuarioCommand, ResponseCommand<IdentityUser>>, UsuarioCommandHandler>();
    }
  }
}
