using PracticeForJudge.Models;

namespace PracticeForJudge.Core.Interfaces
{
    public interface IController
    {
        Box CreateBox(double length, double width, double height);
    }
}
