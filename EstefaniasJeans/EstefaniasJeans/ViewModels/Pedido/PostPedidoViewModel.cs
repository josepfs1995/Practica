using System.Collections.Generic;

namespace EstefaniasJeans.ViewModels.PedidoDetalle
{
  public class PostPedidoViewModel
  {
    public string Descripcion { get; set; }
    public ICollection<PostPedidoDetalleViewModel> PedidoDetalle { get; set; }
  }
}
