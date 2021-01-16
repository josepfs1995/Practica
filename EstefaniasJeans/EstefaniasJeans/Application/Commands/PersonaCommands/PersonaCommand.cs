using System;

namespace EstefaniasJeans.Application.Commands.PersonaCommands
{
  public abstract class PersonaCommand: Command
  {
    public Guid Id_Persona { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Direccion1 { get; set; }
    public string Direccion2 { get; set; }
    public string Documento { get; set; }
    public string Celular { get; set; }
  }
}
