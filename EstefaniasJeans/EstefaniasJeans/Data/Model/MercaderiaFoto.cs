using System;

namespace EstefaniasJeans.Data.Model
{
  public class MercaderiaFoto
  {
    public Guid Id_MercaderiaFoto { get; set; }
    public Guid Id_Mercaderia { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaCreacion { get; set; }
    public Mercaderia Mercaderia { get; set; }
  }
}
