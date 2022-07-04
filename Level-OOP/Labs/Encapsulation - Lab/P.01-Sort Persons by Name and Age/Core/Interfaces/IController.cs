using PracticeForJudge.Models;

namespace PracticeForJudge.Core.Interfaces
{
    public interface IController
    {
        //methods for my models
        Person CreatePerson(string firstName, string lastName, int age);
    }
}
