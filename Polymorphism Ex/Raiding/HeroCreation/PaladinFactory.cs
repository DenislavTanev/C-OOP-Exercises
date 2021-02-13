using Raiding.Models;

namespace Raiding.HeroCreation
{
    public class PaladinFactory : HeroFactory
    {
        private string _name;

        public PaladinFactory(string name)
        {
            _name = name;
        }
        public override BaseHero GetBaseHero()
        {
            return new Paladin(_name);
        }
    }
}
