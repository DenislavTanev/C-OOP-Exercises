using Raiding.Models;

namespace Raiding.HeroCreation
{
    public class DruidFactory : HeroFactory
    {
        private string _name;

        public DruidFactory(string name)
        {
            _name = name;
        }
        public override BaseHero GetBaseHero()
        {
            return new Druid(_name);
        }
    }
}
