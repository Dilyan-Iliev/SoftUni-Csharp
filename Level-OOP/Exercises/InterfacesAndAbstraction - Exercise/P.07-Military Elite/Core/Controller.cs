using LocalPractice.Core.Interfaces;
using LocalPractice.Models;
using LocalPractice.Models.Enumerators;

namespace LocalPractice.Core
{
    public class Controller : IController
    {
        public Commando CreateCommando(int iD, string firstName, string lastName, decimal salary, Corps corps)
         => new Commando(iD, firstName, lastName, salary, corps);

        public Engineer CreateEngineer(int iD, string firstName, string lastName, decimal salary, Corps corps)
         => new Engineer(iD, firstName, lastName, salary, corps);

        public LieutenantGeneral CreateLieutenantGeneral(int iD, string firstName, string lastName, decimal salary)
         => new LieutenantGeneral(iD, firstName, lastName, salary);

        public Mission CreateMission(string codeName, MissionStatus missionStatus)
         => new Mission(codeName, missionStatus);

        public Private CreatePrivate(int iD, string firstName, string lastName, decimal salary)
         => new Private(iD, firstName, lastName, salary);

        public Repair CreateRepair(string partName, int hoursWorked)
         => new Repair(partName, hoursWorked);

        public Spy CreateSpy(int iD, string firstName, string lastName, int codeNumber)
         => new Spy(iD, firstName, lastName, codeNumber);
    }
}
