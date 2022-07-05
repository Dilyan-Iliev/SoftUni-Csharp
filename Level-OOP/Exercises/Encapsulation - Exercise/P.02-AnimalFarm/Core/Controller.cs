using PracticeForJudge.Core.Interfaces;
using PracticeForJudge.Models;

namespace PracticeForJudge.Core
{
    public class Controller : IController
    {
        public Chicken CreateChicken(string name, int age)
         => new Chicken(name, age);
    }
}
