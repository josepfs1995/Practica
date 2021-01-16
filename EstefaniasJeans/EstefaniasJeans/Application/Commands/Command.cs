using FluentValidation.Results;

namespace EstefaniasJeans.Application.Commands
{
  public abstract class Command
  {
    public ValidationResult ValidationResult { get; set; }
    public abstract bool IsValid();
  }
}
