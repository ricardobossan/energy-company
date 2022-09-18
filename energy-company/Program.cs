using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Dominio.Enum;

namespace energy_company
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Endpoint> _endpoints = new List<Endpoint>();
      bool isRunning = true;
      while (isRunning)
      {
        Console.WriteLine(
            "Insert a number from the options and press ENTER:\n\n" +
            "1) Insert a new endpoint\n" +
            "2) Edit an existing endpoint\n" +
            "3) Delete an existing endpoing\n" +
            "4) List all endpoints\n" +
            "5) Find and endpoint by Endpoint Serial Number\n" +
            "6) Exit"
            );

        string input = Console.ReadLine();
        switch (input)
        {
          case "1":
            Endpoint endpoint = new Endpoint();


            Console.WriteLine("Insert the meter model. Options:\n");
            string[] meterModelNames = Enum.GetNames(typeof(MeterModel));
            foreach (string model in meterModelNames) Console.WriteLine(model);
            string MMInput = Console.ReadLine();
try
            {
              if (!meterModelNames.Contains(MMInput)) throw new Exception();
            } catch
            {
// TODO: Tratar exceção.
            }
            Console.WriteLine("Meter Model assigned: " + endpoint.SerialNumber);

            Console.Write("Insert the serial number:");
            string SNInput = Console.ReadLine();
            endpoint.SerialNumber = SNInput;
            Console.WriteLine("Serial Number assigned: " + endpoint.SerialNumber);

            Console.Write("Insert the meter number:");
            string MNInput = Console.ReadLine();
            endpoint.MeterNumber = int.Parse(MNInput);
            Console.WriteLine("Meter number assigned: " + endpoint.MeterNumber);

            Console.Write("Insert the firmeware version:");
            string FVInput = Console.ReadLine();
            endpoint.FirmwareVersion = FVInput;
            Console.WriteLine("Firmware version assigned: " + endpoint.FirmwareVersion);

            Console.Write(
              "Insert the number of the corresponding switch state:\n" +
              "0) Disconnected\n" +
              "1) Connected\n" +
              "2) Armed\n"
              );
            string SSInput = Console.ReadLine();
            endpoint.SwitchState = int.Parse(SSInput);
            Console.WriteLine("SwitchState assigned: " + endpoint.SwitchState);
            _endpoints.Add(endpoint);
            break;
          case "4":
            Console.WriteLine("Endpoints list:\n\n");
            foreach (var e in _endpoints)
            {
              Console.WriteLine(
                "Meter Model: " + Enum.GetName(typeof(MeterModel), e.SwitchState) + "\n" +
                "Serial Number: " + e.SerialNumber + "\n" +
                "Meter Number: " + e.MeterNumber + "\n" +
                "Firmware Version: " + e.FirmwareVersion + "\n"
                );
              Console.WriteLine("\n");
            }
            break;
        }
      }
    }
  }
}
