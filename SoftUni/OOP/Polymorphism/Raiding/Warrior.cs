namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name, int power) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
