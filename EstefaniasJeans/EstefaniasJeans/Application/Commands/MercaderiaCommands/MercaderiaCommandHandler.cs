using System;
using System.Linq;
using AutoMapper;
using EstefaniasJeans.Data.Model;
using EstefaniasJeans.Extensions;
using EstefaniasJeans.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;

namespace EstefaniasJeans.Application.Commands.MercaderiaCommands
{
  public class MercaderiaCommandHandler : CommandHandler<Mercaderia>, 
                                          IRequestHandler<CrearMercaderiaCommand, ResponseCommand<Mercaderia>>,
                                          IRequestHandler<EditarMercaderiaCommand, ResponseCommand<Mercaderia>>,
                                          IRequestHandler<EliminarMercaderiaCommand, ResponseCommand<Mercaderia>>
  {
    private readonly IMapper _mapper;
    private readonly IMercaderiaRepository _mercaderiaRepository;
    private readonly IFileManagment _fileManagment;
    private readonly IHttpContextAccessor _context;
    public MercaderiaCommandHandler(
      IMapper mapper,
      IFileManagment fileManagment,
      IMercaderiaRepository mercaderiaRepository,
      IHttpContextAccessor context)
    {
      _mapper = mapper;
      _mercaderiaRepository = mercaderiaRepository;
      _fileManagment = fileManagment;
      _context = context;
    }
    public async Task<ResponseCommand<Mercaderia>> Handle(CrearMercaderiaCommand request, CancellationToken cancellationToken)
    {
      if (!request.IsValid()) return ManejarRespuesta(request.ValidationResult);

      foreach(var mercaderiaFoto in request.MercaderiaFoto){
        mercaderiaFoto.Nombre = _fileManagment.GuardarFromBase64(request.Id_Mercaderia.ToString(), mercaderiaFoto.Base64, mercaderiaFoto.Nombre);
      }
      var mercaderia = _mapper.Map<Mercaderia>(request);
      mercaderia.Id_Persona = _context.HttpContext.User.ObtenerId();
      _mercaderiaRepository.Create(mercaderia);
      await _mercaderiaRepository.UoW.Save();
      return ManejarRespuesta(request.ValidationResult, mercaderia);
    }
    public async Task<ResponseCommand<Mercaderia>> Handle(EditarMercaderiaCommand request, CancellationToken cancellationToken)
    {
      if (!request.IsValid()) return ManejarRespuesta(request.ValidationResult);

      var mercaderia = await _mercaderiaRepository.Get(request.Id_Mercaderia);
      mercaderia.Nombre = request.Nombre;
      mercaderia.Id_Categoria = request.Id_Categoria;
      mercaderia.FechaCreacion = request.FechaCreacion;
      mercaderia.Stock = request.Stock;
      mercaderia.StockRestante = request.Stock;
      mercaderia.Precio = request.Precio;
      mercaderia.Id_Persona = _context.HttpContext.User.ObtenerId();
      mercaderia.Descripcion = request.Descripcion;
      foreach(var mercaderiaFoto in request.MercaderiaFoto.Where(x=>x.Id_MercaderiaFoto == Guid.Empty)){
         mercaderiaFoto.Nombre = _fileManagment.GuardarFromBase64(mercaderia.Id_Mercaderia.ToString(), mercaderiaFoto.Base64, mercaderiaFoto.Nombre);
      }
      foreach(var mercaderiaFoto in mercaderia.MercaderiaFoto.Where(x=> !request.MercaderiaFoto.Any(y=>y.Id_MercaderiaFoto == x.Id_MercaderiaFoto))){
        _fileManagment.EliminarFromName(mercaderia.Id_Mercaderia.ToString(), mercaderiaFoto.Nombre);
      }
      mercaderia.MercaderiaFoto = _mapper.Map<ICollection<MercaderiaFoto>>(request.MercaderiaFoto);
      _mercaderiaRepository.Editar(mercaderia);
      await _mercaderiaRepository.UoW.Save();
      return ManejarRespuesta(request.ValidationResult, mercaderia);
    }
    public async Task<ResponseCommand<Mercaderia>> Handle(EliminarMercaderiaCommand request, CancellationToken cancellationToken)
    {
       var mercaderia = await _mercaderiaRepository.Get(request.Id_Mercaderia);
       if(mercaderia == null){ 
         AgregarError("No existe la mercaderia que desea eliminar");
         return ManejarRespuesta();
       }
       mercaderia.Estado = false;
       _mercaderiaRepository.Editar(mercaderia);
      await _mercaderiaRepository.UoW.Save();
      return ManejarRespuesta(new ValidationResult(), mercaderia);
    }
  }
}
