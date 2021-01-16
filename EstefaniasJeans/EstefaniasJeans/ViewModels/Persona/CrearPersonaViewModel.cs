using System;
using System.ComponentModel.DataAnnotations;

namespace EstefaniasJeans.ViewModels.Persona
{
  public class CrearPersonaViewModel
  {
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Direccion1 { get; set; }
    public string Direccion2 { get; set; }
    public string Documento { get; set; }
    public string Celular { get; set; }
  }
}
