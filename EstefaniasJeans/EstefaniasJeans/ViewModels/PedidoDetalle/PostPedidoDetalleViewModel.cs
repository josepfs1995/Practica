using System;

namespace EstefaniasJeans.ViewModels.PedidoDetalle
{
  public class PostPedidoDetalleViewModel
  {
    public Guid Id_Mercaderia { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
  }
}
