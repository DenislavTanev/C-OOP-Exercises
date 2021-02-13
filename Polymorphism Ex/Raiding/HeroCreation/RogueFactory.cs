using Raiding.Models;

namespace Raiding.HeroCreation
{
    public class RogueFactory : HeroFactory
    {
        private string _name;

        public RogueFactory(string name)
        {
            _name = name;
        }
        public override BaseHero GetBaseHero()
        {
            return new Rogue(_name);
        }
    }
}
