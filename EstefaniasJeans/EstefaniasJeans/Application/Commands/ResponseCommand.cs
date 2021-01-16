using System.Collections.Generic;

namespace EstefaniasJeans.Application.Commands
{
  public class ResponseCommand<T>
  {
    public bool IsValid { get; set; } = true;
    public ICollection<string> Errors { get; set; } = new List<string>();
    public T Data { get; set; }
  }
}
