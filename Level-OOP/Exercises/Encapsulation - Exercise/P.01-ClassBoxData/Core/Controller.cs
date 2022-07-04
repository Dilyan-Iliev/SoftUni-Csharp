using PracticeForJudge.Core.Interfaces;
using PracticeForJudge.Models;

namespace PracticeForJudge.Core
{
    public class Controller : IController
    {
        public Box CreateBox(double length, double width, double height)
        => new Box(length, width, height);
    }
}
