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
    List<Endpoint> Delete(string serialNumber, IEnumerable<Endpoint> endpoints);
    Endpoint Edit(Endpoint endpoint);
    Endpoint GetBySerialNumber(string serialNumber, IEnumerable<Endpoint> endpoints);
    string List(IEnumerable<Endpoint> endpoints);
  }
}
