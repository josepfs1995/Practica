using System;

namespace EstefaniasJeans.Data.Model
{
  public class PedidoDetalle
  {
    public Guid Id_PedidoDetalle { get; set; }
    public Guid Id_Pedido { get; set; }
    public Guid Id_Mercaderia { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }
    public decimal PrecioTotal { get; set; }
    public Mercaderia Mercaderia { get; set; }
    public Pedido Pedido { get; set; }
  }
}
