using P._04_Recharge.Interfaces;

namespace P._04_Recharge.Models
{
    public abstract class Worker : IWorker
    {
        protected Worker(string iD)
        {
            ID = iD;
        }

        public string ID { get; set; }

        public int WorkingHours { get; protected set; }

        public virtual void Work(int hours)
        {
            WorkingHours += hours;
        }
    }
}
