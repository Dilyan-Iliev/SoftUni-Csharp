namespace PracticeForJudge.Models
{
    using PracticeForJudge.Models.Interfaces;

    public abstract class Hero : IHero
    {
        protected Hero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name {get; protected set;}

        public int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
