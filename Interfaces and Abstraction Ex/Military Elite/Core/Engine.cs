using MilitaryElite.Contracts;
using MilitaryElite.Core.Contracts;
using MilitaryElite.Exeptions;
using MilitaryElite.IO.Contracts;
using MilitaryElite.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<ISoldier> soldiers;
        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string soldierType = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstName = cmdArgs[2];
                string lastName = cmdArgs[3];
                ISoldier soldier = null;            
                if (soldierType == "Private")
                {
                    soldier = AddPrivate(cmdArgs, id, firstName, lastName);
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    LieutenantGeneral general = AddGeneral(cmdArgs, id, firstName, lastName);
                    soldier = general;
                }
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        IEngineer engineer = AddSoldier(cmdArgs, id, firstName, lastName, salary, corps);
                        soldier = engineer;
                    }
                    catch (InvalidCorpsExeption ice)
                    {
                        continue;
                    }
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        ICommando commando = GetCommando(cmdArgs, id, firstName, lastName, salary, corps);
                        soldier = commando;
                    }
                    catch (InvalidCorpsExeption ice)
                    {
                        continue;
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(cmdArgs[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                if (soldier!=null)
                {
                    this.soldiers.Add(soldier);
                }
               
            }
            foreach (var soldier in this.soldiers)
            {
               this.writer.WriteLine(soldier.ToString());
            }
        }

        private static ICommando GetCommando(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);
            string[] missionArgs = cmdArgs
                .Skip(6)
                .ToArray();
            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                try
                {
                    string missionCodeName = missionArgs[i];
                    string missionState = missionArgs[i + 1];
                    IMission mission = new Mission(missionCodeName, missionState);
                    commando.AddMission(mission);
                }
                catch (InvalidMissionStateExeption imse)
                {
                    continue;
                }
            }

            return commando;
        }

        private static IEngineer AddSoldier(string[] cmdArgs, int id, string firstName, string lastName, decimal salary, string corps)
        {
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            string[] repairsArgs = cmdArgs
                .Skip(6)
                .ToArray();
            for (int i = 0; i < repairsArgs.Length; i += 2)
            {
                string partName = repairsArgs[i];
                int hoursWorked = int.Parse(repairsArgs[i + 1]);
                IRepair repair = new Repair(partName, hoursWorked);
                engineer.AddRepair(repair);
            }

            return engineer;
        }

        private LieutenantGeneral AddGeneral(string[] cmdArgs, int id, string firstName, string lastName)
        {
            decimal salary = decimal.Parse(cmdArgs[4]);
            LieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);
            foreach (var pid in cmdArgs.Skip(5))
            {
                ISoldier privateToAdd = this.soldiers.First(s => s.Id == int.Parse(pid));
                general.AddPrivate(privateToAdd);
            }

            return general;
        }
        private static ISoldier AddPrivate(string[] cmdArgs, int id, string firstName, string lastName)
        {
            ISoldier soldier;
            decimal salary = decimal.Parse(cmdArgs[4]);
            soldier = new Private(id, firstName, lastName, salary);
            return soldier;
        }
    }
}
