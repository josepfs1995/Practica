using System;
namespace EstefaniasJeans.Application.Commands.MercaderiaFotoCommands{
  public class EditarMercaderiaFotoCommand:MercaderiaFotoCommand{
    public EditarMercaderiaFotoCommand(Guid id_MercaderiaFoto, string nombre, string base64):base(nombre)
    {
      Id_MercaderiaFoto = id_MercaderiaFoto;
        Base64 = base64;
    }
    public string Base64 { get; set; }
  }
}