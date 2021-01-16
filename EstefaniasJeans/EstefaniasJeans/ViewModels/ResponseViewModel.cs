using System.Collections.Generic;
namespace EstefaniasJeans.ViewModels
{
  public class ResponseViewModel<T>
  {
    public bool IsValid { get; set; } = true;
    public ICollection<string> Errors { get; set; } = new List<string>();
    public T Data { get; set; }
  }
}
