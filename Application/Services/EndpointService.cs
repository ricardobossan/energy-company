using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Enum;
using Dominio.Model;
using Dominio.Services;

namespace Application.Services
{
  public class EndpointService : IEndpointService
  {
    public IEnumerable<Endpoint> Delete(string serialNumber)
    {
      throw new NotImplementedException();
    }

    public Endpoint GetBySerialNumber(string serialNumber)
    {
      throw new NotImplementedException();
    }

    public string List(IEnumerable<Endpoint> endpoints)
    {
      if (endpoints.Count() > 0)
      {
        StringBuilder sbEL = new StringBuilder();
        sbEL.Append("ENDPOINTS LIST:\n\n");
        foreach (var e in endpoints)
        {
          sbEL.Append(
            "Meter Model: " + Enum.GetName(typeof(MeterModel), e.MeterModel) + " (n. " + (int)e.MeterModel + ")" + "\n" +
            "Serial Number: " + e.SerialNumber + "\n" +
            "Meter Number: " + e.MeterNumber + "\n" +
            "Firmware Version: " + e.FirmwareVersion + "\n" +
            "Switch State: " + Enum.GetName(typeof(SwitchState), e.SwitchState) + " (n. " + e.SwitchState + ")"
            );
          sbEL.Append("\n\n");
        }
        return sbEL.ToString();
      }

      throw new Exception("NO ENDPOINT FOUND");
    }
  }
}
