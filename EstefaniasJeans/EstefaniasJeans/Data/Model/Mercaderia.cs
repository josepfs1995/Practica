using System;
using System.Collections.Generic;

namespace EstefaniasJeans.Data.Model
{
  public class Mercaderia
  {
    public Guid Id_Mercaderia { get; set; }
    public Guid Id_Categoria { get; set; }
    public Guid? Id_Persona { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Stock { get; set; }
    public int StockRestante { get; set; }
    public decimal Precio { get; set; }
    public bool Estado { get; set; }
    public DateTime FechaCreacion { get; set; }
    public Categoria Categoria { get; set; }
    public Persona Persona { get; set; }
    public ICollection<MercaderiaFoto> MercaderiaFoto { get; set; }
    public ICollection<PedidoDetalle> PedidoDetalle { get; set; }
  }
}
