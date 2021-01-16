using System;
using System.Collections.Generic;

namespace EstefaniasJeans.Data.Model
{
  public class Categoria
  {
    public Guid Id_Categoria { get; set; }
    public string Nombre { get; set; }
    public ICollection<Mercaderia> Mercaderia { get; set; }
  }
}
