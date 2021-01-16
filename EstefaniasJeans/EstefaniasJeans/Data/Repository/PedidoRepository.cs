using EstefaniasJeans.Data.Model;
using EstefaniasJeans.Data.UoW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstefaniasJeans.Data.Repository
{
  public interface IPedidoRepository
  {
    public IUnitOfWork UoW { get; }
    void Create(Pedido pedido);
    Task<ICollection<Pedido>> Get();
    Task<Pedido> Get(Guid id);
  }
  public class PedidoRepository : IPedidoRepository
  {
    private readonly EstefaniasJeansContext _context;
    public PedidoRepository(EstefaniasJeansContext context)
    {
      _context = context;
    }
    public IUnitOfWork UoW => _context;

    public void Create(Pedido pedido)
    {
      _context.Add(pedido);
    }
    public async Task<ICollection<Pedido>> Get()
    {
      return await _context.Pedidos
              .Include(x=>x.Persona)
              .OrderByDescending(x=>x.Fecha)
              .ToListAsync();
    }
    public async Task<Pedido> Get(Guid id)
    {
      return await _context.Pedidos
              .Include(x => x.PedidoDetalle)
                .ThenInclude(x => x.Mercaderia)
                  .ThenInclude(x => x.Categoria)
                .Include(x => x.PedidoDetalle)
                  .ThenInclude(x => x.Mercaderia)
                    .ThenInclude(x => x.MercaderiaFoto)
              .Include(x=>x.Persona)
              .AsSplitQuery()
              .FirstOrDefaultAsync(x => x.Id_Pedido == id);
    }
    public void Dispose()
    {
      _context.Dispose();
    }
  }
}
