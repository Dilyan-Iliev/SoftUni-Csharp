namespace P._04_Recharge.Interfaces
{
    public interface IRobot
    {
        int Capacity { get; }
        int CurrentPower { get; }
        void Recharge();
    }
}
