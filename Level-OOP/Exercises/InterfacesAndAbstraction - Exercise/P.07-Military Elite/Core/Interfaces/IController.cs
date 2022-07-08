using LocalPractice.Models;
using LocalPractice.Models.Enumerators;

namespace LocalPractice.Core.Interfaces
{
    public interface IController
    {
        Private CreatePrivate(int iD, string firstName, string lastName, decimal salary);

        LieutenantGeneral CreateLieutenantGeneral(int iD, string firstName, string lastName, decimal salary);

        Engineer CreateEngineer(int iD, string firstName, string lastName, decimal salary, Corps corps);

        Commando CreateCommando(int iD, string firstName, string lastName, decimal salary, Corps corps);

        Spy CreateSpy(int iD, string firstName, string lastName, int codeNumber);

        Repair CreateRepair(string partName, int hoursWorked);

        Mission CreateMission(string codeName, MissionStatus missionStatus);
    }
}
