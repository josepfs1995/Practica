using EstefaniasJeans.ViewModels.Mercaderia;
using System;

namespace EstefaniasJeans.ViewModels.PedidoDetalle
{
  public class GetPedidoDetalleViewModel
  {
    public Guid Id_PedidoDetalle { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public decimal PrecioTotal { get; set; }
    public GetMercaderiaViewModel Mercaderia { get; set; }
  }
}
