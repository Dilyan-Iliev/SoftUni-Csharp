using PracticeForJudge.Models;

namespace PracticeForJudge.Core.Interfaces
{
    public interface IController
    {
        Chicken CreateChicken(string name, int age);
    }
}
