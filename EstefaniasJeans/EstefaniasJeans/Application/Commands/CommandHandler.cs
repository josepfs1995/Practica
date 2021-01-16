using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstefaniasJeans.Application.Commands
{
  public class CommandHandler<T>
  {
    protected ResponseCommand<T> ResponseCommand = new ResponseCommand<T>();
    protected ResponseCommand<T> ManejarRespuesta(ValidationResult validationResult)
    {
      ResponseCommand.IsValid = validationResult.IsValid;
      if (!validationResult.IsValid)
      {
        foreach (var error in validationResult.Errors)
        {
          ResponseCommand.Errors.Add(error.ErrorMessage);
        }
      }
      return ResponseCommand;
    }
    protected ResponseCommand<T> ManejarRespuesta(ValidationResult validationResult, T data)
    {
      ResponseCommand.IsValid = validationResult.IsValid;
      if (!validationResult.IsValid)
      {
        foreach (var error in validationResult.Errors)
        {
          ResponseCommand.Errors.Add(error.ErrorMessage);
        }
      }
      ResponseCommand.Data = data;
      return ResponseCommand;
    }
    protected ResponseCommand<T> ManejarRespuesta()
    {
      return ResponseCommand;
    }
    protected void AgregarError(string msg)
    {
      ResponseCommand.IsValid = false;
      ResponseCommand.Errors.Add(msg);
    }
  }
}
