using System;
using System.Collections.Generic;
namespace EstefaniasJeans.Data.Model
{
  public class Persona
  {
    public Guid Id_Persona { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public string Direccion1 { get; set; }
    public string Direccion2 { get; set; }
    public string Documento { get; set; }
    public string Celular { get; set; }
    public ICollection<Mercaderia> Mercaderia { get; set; }
    public ICollection<Pedido> Pedido { get; set; }
  }
}
