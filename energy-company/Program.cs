using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Services;
using Dominio.Enum;
using Dominio.Model;
using Dominio.Services;

namespace energy_company
{
  class Program
  {
    static void Main(string[] args)
    {
      IEndpointService endpointService = new EndpointService();


      List<Endpoint> endpoints = new List<Endpoint>();

      bool isRunning = true;
      while (isRunning)
      {
        Console.ForegroundColor = ConsoleColor.White;
        Print("Insert a number from the options and press ENTER:\n\n" +
                    "1) Insert a new endpoint\n" +
                    "2) Edit an existing endpoint\n" +
                    "3) Delete an existing endpoing\n" +
                    "4) List all endpoints\n" +
                    "5) Find and endpoint by Endpoint Serial Number\n" +
                    "6) Exit"
                    , PrintType.INSTRUCTION);

        char input = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (input)
        {
          case '1':
            #region INSERT_ENDPOINT
            Endpoint endpoint = new Endpoint();

            #region ASSIGN_METER_MODEL
            bool properMMInput = false;
            while (!properMMInput)
            {
              Print("Insert the meter model. Options:", PrintType.INSTRUCTION);
              string[] meterModelNames = Enum.GetNames(typeof(MeterModel));
              foreach (string model in meterModelNames) Console.WriteLine(model);
              string MMInput = Console.ReadLine().ToUpper();

              try
              {
                if (!meterModelNames.Contains(MMInput))
                {
                  throw new Exception("\nThe provided value does not match any known MeterModel. Please try again.\n");
                }

                endpoint.MeterModel = (MeterModel)Enum.Parse(typeof(MeterModel), MMInput);
                endpoint.MeterModelId = (int)endpoint.MeterModel;
                Print("Meter Model assigned: " + Enum.GetName(typeof(MeterModel), endpoint.MeterModel) + " (n. " + (int)endpoint.MeterModel + ")", PrintType.SUCCESS);
                properMMInput = true;
              }
              catch (Exception e)
              {
                Print(e.Message, PrintType.ERROR);
              }
            }
            #endregion
            #region ASSIGN_SERIAL_NUMBER
            Print("Insert the serial number:", PrintType.INSTRUCTION);

            string SNInput = Console.ReadLine();
            endpoint.SerialNumber = SNInput;

            Print("Serial Number assigned: " + endpoint.SerialNumber, PrintType.SUCCESS);
            #endregion
            #region ASSIGN_METER_NUMBER
            Print("Insert the meter number:", PrintType.INSTRUCTION);

            string MNInput = Console.ReadLine();
            endpoint.MeterNumber = int.Parse(MNInput);

            Print("Meter number assigned: " + endpoint.MeterNumber, PrintType.SUCCESS);
            #endregion
            #region ASSIGN_FIRMWARE_VERSION
            Print("Insert the firmeware version:", PrintType.INSTRUCTION);

            string FVInput = Console.ReadLine();
            endpoint.FirmwareVersion = FVInput;

            Print("Firmware version assigned: " + endpoint.FirmwareVersion, PrintType.SUCCESS);
            #endregion
            #region ASSIGN_SWITCHSTATE
            bool properSSInput = false;
            while (!properSSInput)
            {
              Print("Insert the Switch State. Options:\n", PrintType.INSTRUCTION);

              string[] switchStateNames = Enum.GetNames(typeof(SwitchState));
              foreach (string switchState in switchStateNames) Console.WriteLine(switchState);

              string SSInput = Console.ReadLine();

              try
              {
                if (!switchStateNames.Contains(SSInput))
                {
                  throw new Exception("\nThe provided value does not match any known Switch State. Please try again.\n");
                }

                object switchStateEnum = Enum.Parse(typeof(SwitchState), SSInput);
                endpoint.SwitchState = (int)switchStateEnum;

                Print("Switch State assigned: " + endpoint.SwitchState + "(" + Enum.GetName(typeof(SwitchState), switchStateEnum) + ")", PrintType.SUCCESS);

                properSSInput = true;
              }
              catch (Exception e)
              {
                Print(e.Message, PrintType.ERROR);
              }
            }
            #endregion

            endpoints.Add(endpoint);

            StringBuilder sb = new StringBuilder();
            sb.Append("ENDPOINT ADDED:\n\n" +
                          "Meter Model: " + Enum.GetName(typeof(MeterModel), endpoint.MeterModel) + " (n. " + (int)endpoint.MeterModel + ")" + "\n" +
                          "Serial Number: " + endpoint.SerialNumber + "\n" +
                          "Meter Number: " + endpoint.MeterNumber + "\n" +
                          "Firmware Version: " + endpoint.FirmwareVersion + "\n" +
                          "Switch State: " + Enum.GetName(typeof(SwitchState), endpoint.SwitchState) + " (n. " + endpoint.SwitchState + ")");
            sb.Append("\n");
            Print(sb.ToString(), PrintType.DONE);
            #endregion
            break;
          case '4':
            try
            {
              Print(endpointService.List(endpoints), PrintType.DONE);
            }
            catch (Exception e)
            {
              Print(e.Message, PrintType.ERROR);
            }
            break;
          case '5':
            #region FIND_BY_SERIAL_NUMBER

            #endregion
            break;
          case '6':
            #region EXIT
            isRunning = false;
            #endregion
            break;
          default:
            Print("The provided value does not match any of the given options. Please try again.", PrintType.ERROR);
            break;
        }
      }
    }

    public static void Print(string str, PrintType prntType)
    {
      switch (prntType)
      {
        case PrintType.INSTRUCTION:
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine(str);
          Console.ForegroundColor = ConsoleColor.White;
          break;
        case PrintType.SUCCESS:
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine(str);
          Console.ForegroundColor = ConsoleColor.White;
          break;
        case PrintType.DONE:
          Console.ForegroundColor = ConsoleColor.Cyan;
          Console.WriteLine(str);
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine("Press any key to continue\n\n");
          Console.ReadKey();
          Console.WriteLine();
          Console.WriteLine();
          break;
        case PrintType.ERROR:
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(str);
          Console.ForegroundColor = ConsoleColor.White;
          break;
      }
    }
  }
}
