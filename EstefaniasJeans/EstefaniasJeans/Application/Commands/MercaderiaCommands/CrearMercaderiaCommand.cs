using EstefaniasJeans.Application.Commands.MercaderiaCommands.MercaderiaValidation;
using EstefaniasJeans.Application.Commands.MercaderiaFotoCommands;
using EstefaniasJeans.Data.Model;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;

namespace EstefaniasJeans.Application.Commands.MercaderiaCommands
{
  public class CrearMercaderiaCommand:MercaderiaCommand<CrearMercaderiaFotoCommand>, IRequest<ResponseCommand<Mercaderia>>
  {
    public CrearMercaderiaCommand(Guid id_Persona, Guid id_Categoria, string nombre, string descripcion, int stock, decimal precio, ICollection<CrearMercaderiaFotoCommand> mercaderiaFoto)
    {
      Id_Persona = id_Persona;
      Id_Categoria = id_Categoria;
      Id_Mercaderia = Guid.NewGuid();
      Nombre = nombre;
      Descripcion = descripcion;
      Stock = stock;
      StockRestante = stock;
      Precio = precio;
      FechaCreacion = DateTime.Now;
      Estado = true;
      MercaderiaFoto = mercaderiaFoto;
    }

      

    public override bool IsValid()
    {
      ValidationResult = new CrearMercaderiaValidation().Validate(this);
      return ValidationResult.IsValid;
    }
  }
}
