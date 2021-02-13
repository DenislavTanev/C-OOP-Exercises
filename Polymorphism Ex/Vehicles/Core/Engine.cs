using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vehicles.Core.Contract;
using Vehicles.IO;
using Vehicles.Vehicles;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private ConsoleReader reader;
        private ConsoleWriter writer;

        public Engine(ConsoleReader reader, ConsoleWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string[] CarArgs = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Car car = new Car(double.Parse(CarArgs[1]), double.Parse(CarArgs[2]));

            string[] TruckArgs = reader.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Truck truck = new Truck(double.Parse(TruckArgs[1]), double.Parse(TruckArgs[2]));

            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] CmdArgs = reader.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string result = null;
                if (CmdArgs[0] == "Drive")
                {
                    if (CmdArgs[1] == "Car")
                    {
                        result = car.Drive(double.Parse(CmdArgs[2]));
                    }
                    else if(CmdArgs[1] == "Truck")
                    {
                        result = truck.Drive(double.Parse(CmdArgs[2]));
                    }
                    writer.WriteLine(result);
                }
                else if(CmdArgs[0] == "Refuel")
                {
                    if (CmdArgs[1] == "Car")
                    {
                        car.Refuel(double.Parse(CmdArgs[2]));
                    }
                    else if (CmdArgs[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(CmdArgs[2]));
                    }
                }
                
            }
            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
        }
    }
}
