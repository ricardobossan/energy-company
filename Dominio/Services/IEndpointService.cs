using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Model;

namespace Dominio.Services
{
  public interface IEndpointService
  {
    string List(IEnumerable<Endpoint> endpoints);
    Endpoint GetBySerialNumber(string serialNumber);
    IEnumerable<Endpoint> Delete(string serialNumber);
  }
}
