using EstefaniasJeans.Data.Model;
using EstefaniasJeans.Data.UoW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstefaniasJeans.Data.Repository
{
  public interface ICategoriaRepository
  {
    public IUnitOfWork UoW { get;}
    Task<ICollection<Categoria>> Get();
  }
  public class CategoriaRepository : ICategoriaRepository
  {
    private EstefaniasJeansContext _context;
    public CategoriaRepository(EstefaniasJeansContext context)
    {
      _context = context;
    }
    public IUnitOfWork UoW => _context;
    public async Task<ICollection<Categoria>> Get()
    {
      return await _context.Categoria.ToListAsync();
    }
    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
