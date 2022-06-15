namespace P._07_Military_Elite.Interfaces
{
    public interface IPrivate : ISoldier
    {//ако някой имплементира IPrivate то ще е нужно да имплементира и методите от ISoldier
        decimal Salary { get; set; }
    }
}
