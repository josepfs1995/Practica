using AutoMapper;
using EstefaniasJeans.Data;
using EstefaniasJeans.Data.Model;
using EstefaniasJeans.Data.UoW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstefaniasJeans.Repository
{
  public interface IMercaderiaRepository
  {
    IUnitOfWork UoW { get; }
    Task<ICollection<Mercaderia>> Get();
    Task<Mercaderia> Get(Guid id);
    void Create(Mercaderia mercaderia);
    void Editar(Mercaderia mercaderia);
  }
  public class MercaderiaRepository : IMercaderiaRepository
  {
    private readonly EstefaniasJeansContext _context;
    public IUnitOfWork UoW => _context;
    public MercaderiaRepository(EstefaniasJeansContext context)
    {
      _context = context;
    }
    public async Task<ICollection<Mercaderia>> Get()
    {
      return await _context.Mercaderias
              .Include(x=>x.MercaderiaFoto)
              .Include(x=>x.Categoria)
              .ToListAsync();
    }
    public async Task<Mercaderia> Get(Guid id)
    {
      return await _context.Mercaderias
              .Include(x => x.MercaderiaFoto)
              .FirstOrDefaultAsync(x=>x.Id_Mercaderia == id);
    }
    public void Create(Mercaderia mercaderia)
    {
      _context.Mercaderias.Add(mercaderia);
    }
     public void Editar(Mercaderia mercaderia)
    {
      _context.Mercaderias.Update(mercaderia);
    }
    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
