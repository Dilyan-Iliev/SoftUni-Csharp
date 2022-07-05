using P._04_Recharge.Interfaces;
using P._04_Recharge.Models;

namespace P._04_Recharge
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWorker robot = new Robot("5", 10);
            robot.Work(5);
        }
    }
}
