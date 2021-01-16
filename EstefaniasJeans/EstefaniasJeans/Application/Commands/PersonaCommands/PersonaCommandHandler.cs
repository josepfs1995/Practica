using AutoMapper;
using EstefaniasJeans.Data.Model;
using EstefaniasJeans.Data.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EstefaniasJeans.Application.Commands.PersonaCommands
{
  public class PersonaCommandHandler : CommandHandler<Persona>, IRequestHandler<CrearPersonaCommand, ResponseCommand<Persona>>
  {
    private readonly IMapper _mapper;
    private readonly IPersonaRepository _personaRepository;
    public PersonaCommandHandler(IMapper mapper,
                                IPersonaRepository personaRepository)
    {
      _personaRepository = personaRepository;
      _mapper = mapper;
    }
    public async Task<ResponseCommand<Persona>> Handle(CrearPersonaCommand request, CancellationToken cancellationToken)
    {
      if (!request.IsValid()) return ManejarRespuesta(request.ValidationResult);

      var persona = _mapper.Map<Persona>(request);
      _personaRepository.Create(persona);
      await _personaRepository.UoW.Save();

      return ManejarRespuesta(request.ValidationResult, persona);
    }
  }
}
