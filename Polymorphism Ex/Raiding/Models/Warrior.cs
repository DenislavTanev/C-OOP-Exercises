namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int HERO_POWER = 100;

        private readonly string _heroType;
        private string _name;

        public Warrior(string name)
        {
            _name = name;
            _heroType = "Warrior";
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
