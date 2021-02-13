using Raiding.Core.Contracts;
using Raiding.Exceptions;
using Raiding.HeroCreation;
using Raiding.IO;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding.Core
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
            HeroFactory factory = null;

            int heroCount = 0;
            List<BaseHero> Heroes = new List<BaseHero>();

            int N = int.Parse(reader.ReadLine());

            while (heroCount < N)
            {
                string heroName = reader.ReadLine();
                string heroType = reader.ReadLine();

                try
                {
                    switch (heroType)
                    {
                        case "Druid":
                            factory = new DruidFactory(heroName);
                            break;
                        case "Paladin":
                            factory = new PaladinFactory(heroName);
                            break;
                        case "Rogue":
                            factory = new RogueFactory(heroName);
                            break;
                        case "Warrior":
                            factory = new WarriorFactory(heroName);
                            break;
                        default:
                            throw new InvalidHeroException();
                    }
                    Heroes.Add(factory.GetBaseHero());
                    heroCount++;
                }
                catch (InvalidHeroException ihe)
                {

                    writer.WriteLine(ihe.Message);
                }
                
            }

            int bossPower = int.Parse(reader.ReadLine());
            int totalPower = 0;
            foreach (var hero in Heroes)
            {
                writer.WriteLine(hero.CastAbility());
                totalPower += hero.Power;
            }

            if (totalPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
