namespace P._04_Recharge.Interfaces
{
    public interface IWorker
    {
        string ID { get; }
        void Work(int hours);
    }
}
