using EstefaniasJeans.ViewModels.MercaderiaFoto;
using System;
using System.Collections.Generic;

namespace EstefaniasJeans.ViewModels.Mercaderia
{
  public class PutMercaderiaViewModel
  {
    public Guid Id_Mercaderia {get;set;}
    public Guid Id_Persona { get; set; }
    public Guid Id_Categoria { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Stock { get; set; }
    public decimal Precio { get; set; }
    public ICollection<PutMercaderiaFotoViewModel> MercaderiaFoto { get; set; }
  }
}
