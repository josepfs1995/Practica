using AutoMapper;
using EstefaniasJeans.Data.Model;
using EstefaniasJeans.Data.Repository;
using EstefaniasJeans.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EstefaniasJeans.Application.Commands.UsuarioCommands
{
  public class UsuarioCommandHandler : CommandHandler<IdentityUser>, 
                                      IRequestHandler<RegistrarUsuarioCommand, ResponseCommand<IdentityUser>>,
                                      IRequestHandler<LoginUsuarioCommand, ResponseCommand<IdentityUser>>
  {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signIn;
    public UsuarioCommandHandler(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signIn,
                                IMediator mediator,
                                IMapper mapper)
    {
      _mapper = mapper;
      _userManager = userManager;
      _mediator = mediator;
      _signIn = signIn;
    }
    public async Task<ResponseCommand<IdentityUser>> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
    {
      if (!request.IsValid() || !request.Persona.IsValid()) return ManejarRespuesta(request.ValidationResult);

      var user = new IdentityUser
      {
        Email = request.Email,
        UserName = request.Email,
        EmailConfirmed = true,
        PhoneNumber = request.Persona.Celular
      };

      var result = await _userManager.CreateAsync(user, request.Contrasena);
      if (!result.Succeeded)
      {
        foreach (var error in result.Errors)
        {
          AgregarError(error.Description);
        }
        return ManejarRespuesta();
      }

      await _userManager.AddToRoleAsync(user, "Administrador");
      request.Persona.Id_Persona = new Guid(user.Id);
      var persona = await _mediator.Send(request.Persona);
      if (persona.IsValid)
      {
        return ManejarRespuesta(request.ValidationResult, user);
      }

      await _userManager.DeleteAsync(user);

      AgregarError("No se pudó generar el usuario...");
      return ManejarRespuesta();
    }

    public async Task<ResponseCommand<IdentityUser>> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
    {
      if (!request.IsValid()) return ManejarRespuesta(request.ValidationResult);

      var result = await _signIn.PasswordSignInAsync(request.Email, request.Contrasena,
                false, false);

      if (result.Succeeded)
      {
        return ManejarRespuesta(request.ValidationResult, new IdentityUser(request.Email));
      }
      AgregarError("Usuario o contraseña incorrecto");
      return ManejarRespuesta();
    }
  }
}
