using EstefaniasJeans.ViewModels.Persona;
using System.ComponentModel.DataAnnotations;

namespace EstefaniasJeans.ViewModels.Usuario
{
  public class CrearUsuarioViewModel
  {
    public CrearUsuarioViewModel()
    {

    }
    public CrearUsuarioViewModel(string email, string contrasena, string confirmarContrasena, CrearPersonaViewModel persona)
    {
      Email = email;
      Contrasena = contrasena;
      ConfirmarContrasena = confirmarContrasena;
      Persona = persona;
    }
    public string Email { get; set; }
    public string Contrasena { get; set; }
    public string ConfirmarContrasena { get; set; }
    public CrearPersonaViewModel Persona { get; set; }
  }
}
