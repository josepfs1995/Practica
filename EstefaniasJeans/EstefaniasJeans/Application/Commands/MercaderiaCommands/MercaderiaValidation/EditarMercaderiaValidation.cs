using FluentValidation;
using EstefaniasJeans.Application.Commands.MercaderiaFotoCommands;

namespace EstefaniasJeans.Application.Commands.MercaderiaCommands.MercaderiaValidation
{
  public class EditarMercaderiaValidation:MercaderiaValidation<EditarMercaderiaCommand, EditarMercaderiaFotoCommand>
  {
    public EditarMercaderiaValidation()
    {
      ValidarNombre();
      ValidarPrecio();
      ValidarStock();
      ValidarFotos();
    }
    
  }
}
