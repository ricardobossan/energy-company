using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Enum;

namespace Dominio.Model
{
  public class Endpoint
  {
    public int Id { get; set; }
    public int MeterModelId { get; set; }
    public MeterModel MeterModel { get; set; }
    public string SerialNumber { get; set; }
    public int MeterNumber { get; set; }
    public string FirmwareVersion { get; set; }
    public int SwitchState { get; set; }
  }
}
