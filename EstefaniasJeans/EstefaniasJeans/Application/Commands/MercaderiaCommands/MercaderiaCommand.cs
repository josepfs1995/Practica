using System;
using System.Collections.Generic;
using EstefaniasJeans.Application.Commands.MercaderiaFotoCommands;
namespace EstefaniasJeans.Application.Commands.MercaderiaCommands
{
  public abstract class MercaderiaCommand<T>:Command where T: MercaderiaFotoCommand
  {
    public Guid Id_Mercaderia { get; set; }
    public Guid Id_Persona { get; set; }
    public Guid Id_Categoria { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Stock { get; set; }
    public int StockRestante { get; set; }
    public decimal Precio { get; set; }
    public DateTime FechaCreacion { get; set; }
    public bool Estado { get; set; }
    public ICollection<T> MercaderiaFoto { get; set; }  
  }
}
