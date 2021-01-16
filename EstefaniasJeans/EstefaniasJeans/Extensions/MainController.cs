using AutoMapper;
using EstefaniasJeans.Application.Commands;
using EstefaniasJeans.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EstefaniasJeans.Extensions
{
  [ApiController]
  public class MainController:ControllerBase
  {
    protected readonly IMapper _mapper;
    public MainController(IMapper mapper)
    {
      _mapper = mapper;
    }
    protected IActionResult ResponseCustomizado<T>(ResponseViewModel<T> response)
    {
      if (response.IsValid)
      {
        return Ok(response);
      }
      else
      {
        return BadRequest(response);
      }
    }
    protected IActionResult ResponseCustomizado<T, TResult>(ResponseCommand<T> response, TResult Type)
    {
      var responseViewModel = new ResponseViewModel<TResult>
      {
        IsValid = response.IsValid,
        Errors = response.Errors,
        Data = _mapper.Map<TResult>(response.Data)
      };
      return ResponseCustomizado(responseViewModel);
    }
    protected IActionResult ResponseCustomizado<T>(T data)
    {
      var responseCommand = new ResponseViewModel<T>();
      responseCommand.Data = data;
      return ResponseCustomizado(responseCommand);
    }
    protected IActionResult CrearError(string msg)
    {
      var responseCommand = new ResponseViewModel<object>();
      responseCommand.IsValid = false;
      responseCommand.Errors.Add(msg);
      responseCommand.Data = null;
      return ResponseCustomizado(responseCommand);
    }
  }
}
