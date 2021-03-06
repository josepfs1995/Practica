using EstefaniasJeans.Application.Commands.MercaderiaCommands.MercaderiaValidation;
using EstefaniasJeans.Application.Commands.MercaderiaFotoCommands;
using EstefaniasJeans.Data.Model;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;

namespace EstefaniasJeans.Application.Commands.MercaderiaCommands
{
  public class EditarMercaderiaCommand:MercaderiaCommand<EditarMercaderiaFotoCommand>, IRequest<ResponseCommand<Mercaderia>>
  {
    public EditarMercaderiaCommand(Guid id_Mercaderia, Guid id_Persona, Guid id_Categoria, string nombre, string descripcion, int stock, decimal precio, ICollection<EditarMercaderiaFotoCommand> mercaderiaFoto)
    {
      Id_Mercaderia = id_Mercaderia;
      Id_Persona = id_Persona;
      Id_Categoria = id_Categoria;
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
      ValidationResult = new EditarMercaderiaValidation().Validate(this);
      return ValidationResult.IsValid;
    }
  }
}
