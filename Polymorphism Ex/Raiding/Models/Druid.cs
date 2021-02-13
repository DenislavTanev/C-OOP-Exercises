namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int HERO_POWER = 80;

        private readonly string _heroType;
        private string _name;

        public Druid(string name)
        {
            _name = name;
            _heroType = "Druid";
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
