namespace PracticeForJudge.Core.Factories.Interfaces
{
    using PracticeForJudge.Models.Interfaces;

    public interface IHeroFactory
    {
        IHero Create(string heroType, string heroName);
    }
}
