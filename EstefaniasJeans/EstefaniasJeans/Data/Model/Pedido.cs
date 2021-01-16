using System;
using System.Collections.Generic;

namespace EstefaniasJeans.Data.Model
{
  public class Pedido
  {
    public Guid Id_Pedido { get; set; }
    public Guid Id_Persona { get; set; }
    public DateTime Fecha { get; set; }
    public string Descripcion { get; set; }
    public decimal PrecioTotal { get; set; }
    public Persona Persona {get;set;}
    public ICollection<PedidoDetalle> PedidoDetalle { get; set; }
  }
}
