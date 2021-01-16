using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstefaniasJeans.Data.UoW
{
  public interface IUnitOfWork
  {
    Task<bool> Save();
  }
}
