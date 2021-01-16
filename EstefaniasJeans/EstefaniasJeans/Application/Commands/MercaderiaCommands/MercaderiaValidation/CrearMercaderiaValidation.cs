using EstefaniasJeans.Application.Commands.MercaderiaFotoCommands;
namespace EstefaniasJeans.Application.Commands.MercaderiaCommands.MercaderiaValidation
{
  public class CrearMercaderiaValidation:MercaderiaValidation<CrearMercaderiaCommand, CrearMercaderiaFotoCommand>
  {
    public CrearMercaderiaValidation()
    {
      ValidarNombre();
      ValidarPrecio();
      ValidarStock();
      ValidarFotos();
    }
  }
}
