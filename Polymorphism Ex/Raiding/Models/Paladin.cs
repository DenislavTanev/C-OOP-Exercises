namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int HERO_POWER = 100;

        private readonly string _heroType;
        private string _name;

        public Paladin(string name)
        {
            _name = name;
            _heroType = "Paladin";
        }

        public override string Name
        {
            get => _name;
            set => _name = value;
        }

        public override int Power => HERO_POWER;

        public override string CastAbility()
        {
            return $"{_heroType} - {this.Name} healed for {this.Power}";
        }
    }
}
