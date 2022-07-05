using P._04_Recharge.Interfaces;

namespace P._04_Recharge.Models
{
    public class Robot : Worker, IRobot
    {
        private int capacity;
        public Robot(string iD, int capacity) : base(iD)
        {
            this.capacity = capacity;
        }

        public int Capacity { get; }

        public int CurrentPower { get; private set; }

        public void Recharge()
        {
            this.CurrentPower = this.capacity;
        }

        public override void Work(int hours)
        {
            if (hours > this.CurrentPower)
            {
                hours = CurrentPower;
            }

            base.Work(hours);
            this.CurrentPower -= hours;
        }
    }
}
