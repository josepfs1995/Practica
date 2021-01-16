using System;
namespace EstefaniasJeans.Application.Commands.MercaderiaFotoCommands{
  public class CrearMercaderiaFotoCommand:MercaderiaFotoCommand{
    public CrearMercaderiaFotoCommand(string nombre, string base64):base(nombre)
    {
      Base64 = base64;
    }
    public string Base64 { get; set; }
  }
}