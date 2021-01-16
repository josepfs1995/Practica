using AutoMapper;
using EstefaniasJeans.Data.Repository;
using EstefaniasJeans.Extensions;
using EstefaniasJeans.ViewModels;
using EstefaniasJeans.ViewModels.Categoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstefaniasJeans.Controllers
{
  [AllowAnonymous]
  [Route("api/[controller]")]
  public class CategoriaController : MainController
  {
    private readonly ICategoriaRepository _categoriaRepository;
    public CategoriaController(IMapper mapper,
                              ICategoriaRepository categoriaRepository):base(mapper)
    {
      _categoriaRepository = categoriaRepository;
    }
    [HttpGet]
    [ProducesResponseType(typeof(ResponseViewModel<ICollection<GetCategoriaViewModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseViewModel<ICollection<GetCategoriaViewModel>>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
      var categorias = _mapper.Map<ICollection<GetCategoriaViewModel>>(await _categoriaRepository.Get());
      return ResponseCustomizado(categorias);
    }
  }
}
