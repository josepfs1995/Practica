using AutoMapper;
using EstefaniasJeans.Data.Model;
using EstefaniasJeans.ViewModels.Categoria;
using EstefaniasJeans.ViewModels.Mercaderia;
using EstefaniasJeans.ViewModels.MercaderiaFoto;
using EstefaniasJeans.ViewModels.Pedido;
using EstefaniasJeans.ViewModels.PedidoDetalle;
using EstefaniasJeans.ViewModels.Persona;

namespace EstefaniasJeans.Application.Mapper
{
  public class DataToViewModelMapper:Profile
  {
    public DataToViewModelMapper()
    {
      CreateMap<Mercaderia, GetMercaderiaViewModel>();
      CreateMap<MercaderiaFoto, GetMercaderiaFotoViewModel>();
      CreateMap<Categoria, GetCategoriaViewModel>();
      CreateMap<Pedido, GetPedidoViewModel>();
      CreateMap<PedidoDetalle, GetPedidoDetalleViewModel>();
      CreateMap<Persona, GetPersonaViewModel>();
    }
  }
}
