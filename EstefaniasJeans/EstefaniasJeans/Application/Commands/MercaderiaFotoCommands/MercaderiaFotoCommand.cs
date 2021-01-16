using System;

namespace EstefaniasJeans.Application.Commands.MercaderiaFotoCommands
{
  public class MercaderiaFotoCommand
  {
    public MercaderiaFotoCommand(string nombre)
    {
      Nombre = nombre;
      FechaCreacion = DateTime.Now;
      Estado = true;
    }
    public Guid Id_MercaderiaFoto { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Estado { get; set; }
  }
}
