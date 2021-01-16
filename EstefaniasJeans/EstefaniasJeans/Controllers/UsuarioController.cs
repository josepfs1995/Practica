using AutoMapper;
using EstefaniasJeans.Application.Commands.PersonaCommands;
using EstefaniasJeans.Application.Commands.UsuarioCommands;
using EstefaniasJeans.Extensions;
using EstefaniasJeans.ViewModels;
using EstefaniasJeans.ViewModels.Usuario;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EstefaniasJeans.Controllers
{
  [Route("api/token")]
  public class UsuarioController:MainController
  {
    private readonly IMediator _mediator;
    private readonly AppSettingToken _token;
    private readonly UserManager<IdentityUser> _userManager;
    public UsuarioController(IMapper mapper,
                            IMediator mediator,
                            IOptions<AppSettingToken> token,
                            UserManager<IdentityUser> userManager):base(mapper)
    {
      _mediator = mediator;
      _token = token.Value;
      _userManager = userManager;
    }
    [HttpPost("login")]
    [ProducesResponseType(typeof(ResponseViewModel<UsuarioRespuestaViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseViewModel<IdentityUser>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(LoginUsuarioViewModel request)
    {
      var command = new LoginUsuarioCommand(request.Email, request.Contrasena);
      var result = await _mediator.Send(command);
      if (result.IsValid)
      {
        var generarToken = await GenerarToken(result.Data.UserName);
        var response = new ResponseViewModel<UsuarioRespuestaViewModel> { IsValid = true, Errors = new string[] { }, Data = generarToken };
        return Ok(response);
      }
      else
      {
        return BadRequest(result);
      }
    }

    [HttpPost("cuenta-nueva")]
    [ProducesResponseType(typeof(ResponseViewModel<UsuarioRespuestaViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseViewModel<IdentityUser>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Registrar(CrearUsuarioViewModel request)
    {
      var persona = new CrearPersonaCommand(request.Persona.Nombres, request.Persona.Apellidos, request.Persona.FechaNacimiento, request.Persona.Direccion1, request.Persona.Direccion2, request.Persona.Documento, request.Persona.Celular);
      var command = new RegistrarUsuarioCommand(request.Email, request.Contrasena, request.ConfirmarContrasena, persona);
      var result = await _mediator.Send(command);
      if (result.IsValid)
      {
        var generarToken = await GenerarToken(result.Data.Email);
        var response = new ResponseViewModel<UsuarioRespuestaViewModel> { IsValid = true, Errors = new string[] { }, Data = generarToken };
        return Ok(response);
      }
      else
      {
        return BadRequest(result);
      }
    }

    private async Task<UsuarioRespuestaViewModel> GenerarToken(string email)
    {
      var user = await _userManager.FindByEmailAsync(email);
      var claimsIdentity = await ObtenerClaims(user);
      var token = CodificarToken(claimsIdentity);
      return ObtenerRepuestaToken(token, user, claimsIdentity.Claims);
    }
    private async Task<ClaimsIdentity> ObtenerClaims(IdentityUser user)
    {
      var userRole = await _userManager.GetRolesAsync(user);

      var claims = new List<Claim>();
      claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
      claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
      claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

      foreach (var rol in userRole)
      {
        claims.Add(new Claim("role", rol));
      }

      var claimIdentity = new ClaimsIdentity();
      claimIdentity.AddClaims(claims);
      return claimIdentity;
    }
    private string CodificarToken(ClaimsIdentity identityClaims)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_token.Secret);
      var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
      {
        Issuer = _token.Issuer,
        Audience = _token.Audience,
        Subject = identityClaims,
        Expires = DateTime.UtcNow.AddHours(_token.Expires),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      });

      return tokenHandler.WriteToken(token);
    }

    private UsuarioRespuestaViewModel ObtenerRepuestaToken(string token, IdentityUser user, IEnumerable<Claim> claims)
    {
      return new UsuarioRespuestaViewModel
      {
        AccessToken = token,
        ExpiresIn = TimeSpan.FromHours(_token.Expires).TotalSeconds,
        UsuarioToken = new UsuarioToken
        {
          Id = user.Id,
          Email = user.Email,
          Claims = claims.Select(c => new UsuarioClaim { Type = c.Type, Value = c.Value })
        }
      };
    }
  }
}
