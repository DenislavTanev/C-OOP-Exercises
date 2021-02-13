namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int HERO_POWER = 80;

        private readonly string _heroType;
        private string _name;

        public Rogue(string name)
        {
            _name = name;
            _heroType = "Rogue";
        }

        public override string Name
        {
            get => _name;
            set => _name = value;
        }

        public override int Power => HERO_POWER;

        public override string CastAbility()
        {
            return $"{_heroType} - {this.Name} hit for {this.Power} damage";
        }
    }
}
