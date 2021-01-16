using EstefaniasJeans.Data.Model;
using EstefaniasJeans.Data.UoW;

namespace EstefaniasJeans.Data.Repository
{
  public interface IPersonaRepository
  {
    public IUnitOfWork UoW { get; }
    void Create(Persona persona);
  }
  public class PersonaRepository : IPersonaRepository
  {
    private readonly EstefaniasJeansContext _context;
    public PersonaRepository(EstefaniasJeansContext context)
    {
      _context = context;
    }
    public IUnitOfWork UoW => _context;

    public void Create(Persona persona)
    {
      _context.Add(persona);
    }
  }
}
