using EstefaniasJeans.ViewModels.PedidoDetalle;
using EstefaniasJeans.ViewModels.Persona;
using System;
using System.Collections.Generic;

namespace EstefaniasJeans.ViewModels.Pedido
{
  public class GetPedidoViewModel
  {
    public Guid Id_Pedido { get; set; }
    public DateTime Fecha { get; set; }
    public string Descripcion { get; set; }
    public decimal PrecioTotal { get; set; }
    public GetPersonaViewModel Persona { get; set;}
    public ICollection<GetPedidoDetalleViewModel> PedidoDetalle { get; set; }
  }
}
