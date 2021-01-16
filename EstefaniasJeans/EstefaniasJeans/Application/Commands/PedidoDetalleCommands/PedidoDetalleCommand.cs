using System;
namespace EstefaniasJeans.Application.Commands.PedidoDetalleCommands
{
  public class PedidoDetalleCommand
  {
    public PedidoDetalleCommand(Guid id_Mercaderia, int cantidad, decimal precio)
    {
      Id_PedidoDetalle = Guid.NewGuid();
      Cantidad = cantidad;
      Precio = precio;
      Id_Mercaderia = id_Mercaderia;
    }
    public Guid Id_PedidoDetalle { get; set; }
    public Guid Id_Mercaderia { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
  }
}
