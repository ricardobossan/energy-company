using System;
using System.Collections.Generic;
using System.Linq;
using Dominio.Enum;
using Dominio.Model;

namespace energy_company
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Endpoint> _endpoints = new List<Endpoint>();
      Console.ForegroundColor = ConsoleColor.White;

      bool isRunning = true;
      while (isRunning)
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(
            "Insert a number from the options and press ENTER:\n\n" +
            "1) Insert a new endpoint\n" +
            "2) Edit an existing endpoint\n" +
            "3) Delete an existing endpoing\n" +
            "4) List all endpoints\n" +
            "5) Find and endpoint by Endpoint Serial Number\n" +
            "6) Exit"
            );
        Console.ForegroundColor = ConsoleColor.White;

        char input = Console.ReadKey().KeyChar;
        switch (input)
        {
          case '1':
            Endpoint endpoint = new Endpoint();

            #region ASSIGN_METERMODEL
            bool properMMInput = false;
            while (!properMMInput)
            {
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.WriteLine("\nInsert the meter model. Options:\n");
              Console.ForegroundColor = ConsoleColor.White;
              string[] meterModelNames = Enum.GetNames(typeof(MeterModel));
              foreach (string model in meterModelNames) Console.WriteLine(model);
              string MMInput = Console.ReadLine();

              try
              {
                if (!meterModelNames.Contains(MMInput))
                {
                  throw new Exception("\nThe provided value does not match any known MeterModel. Please try again.\n");
                }

                endpoint.MeterModel = (MeterModel)Enum.Parse(typeof(MeterModel), MMInput);
                endpoint.MeterModelId = (int)endpoint.MeterModel;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Meter Model assigned: " + Enum.GetName(typeof(MeterModel), endpoint.MeterModel));
                Console.ForegroundColor = ConsoleColor.White;
                properMMInput = true;
              }
              catch (Exception e)
              {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
              }
            }
            #endregion

            #region ASSIGN_SERIALNUMBER
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Insert the serial number:");
            Console.ForegroundColor = ConsoleColor.White;

            string SNInput = Console.ReadLine();
            endpoint.SerialNumber = SNInput;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Serial Number assigned: " + endpoint.SerialNumber);
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            #region ASSIGN_METERNUMBER
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Insert the meter number:");
            Console.ForegroundColor = ConsoleColor.White;

            string MNInput = Console.ReadLine();
            endpoint.MeterNumber = int.Parse(MNInput);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Meter number assigned: " + endpoint.MeterNumber);
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            #region ASSIGN_FIRMWAREVERSION
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Insert the firmeware version:");
            Console.ForegroundColor = ConsoleColor.White;

            string FVInput = Console.ReadLine();
            endpoint.FirmwareVersion = FVInput;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Firmware version assigned: " + endpoint.FirmwareVersion);
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            #region ASSIGN_SWITCHSTATE
            bool properSSInput = false;
            while (!properSSInput)
            {
              Console.ForegroundColor = ConsoleColor.Yellow;
              Console.WriteLine("Insert the Switch State. Options:\n");
              Console.ForegroundColor = ConsoleColor.White;

              string[] switchStateNames = Enum.GetNames(typeof(SwitchState));
              foreach (string switchState in switchStateNames) Console.WriteLine(switchState);

              string SSInput = Console.ReadLine();

              try
              {
                //TODO: ERRO Cadeia de caracteres não reconhecida.
                if (!switchStateNames.Contains(SSInput.ToString()))
                {
                  throw new Exception("\nThe provided value does not match any known Switch State. Please try again.\n");
                }

                endpoint.SwitchState = int.Parse(SSInput);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Switch State assigned: " + endpoint.SwitchState);
                Console.ForegroundColor = ConsoleColor.White;

                properSSInput = true;
              }
              catch (Exception e)
              {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
              }
            }
            #endregion

            _endpoints.Add(endpoint);
            break;
          case '4':
            Console.WriteLine("Endpoints list:\n\n");
            foreach (var e in _endpoints)
            {
              Console.WriteLine(
                "Meter Model: " + Enum.GetName(typeof(MeterModel), e.MeterModel) + "\n" +
                "Serial Number: " + e.SerialNumber + "\n" +
                "Meter Number: " + e.MeterNumber + "\n" +
                "Firmware Version: " + e.FirmwareVersion + "\n" +
                "Switch State: " + Enum.GetName(typeof(SwitchState), e.SwitchState) + "(Number " + e.SwitchState + ")"
                );
              Console.WriteLine("\n");
            }
            break;
          case '6':
            isRunning = false;
            break;
          default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nThe provided value does not match any of the given options. Please try again.\n");
            Console.ForegroundColor = ConsoleColor.White;
            break;
        }
      }
    }
  }
}
