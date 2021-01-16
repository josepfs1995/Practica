using EstefaniasJeans.Data.Model;
using EstefaniasJeans.ViewModels.Categoria;
using EstefaniasJeans.ViewModels.MercaderiaFoto;
using System;
using System.Collections.Generic;

namespace EstefaniasJeans.ViewModels.Mercaderia
{
  public class GetMercaderiaViewModel
  {
    public Guid Id_Mercaderia { get; set; }
    public Guid Id_Categoria { get; set; }  
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int Stock { get; set; }
    public int StockRestante { get; set; }
    public decimal Precio { get; set; }
    public bool Estado{get;set;}
    public GetCategoriaViewModel Categoria  { get; set; }
    public ICollection<GetMercaderiaFotoViewModel> MercaderiaFoto { get; set; }
  }
}
