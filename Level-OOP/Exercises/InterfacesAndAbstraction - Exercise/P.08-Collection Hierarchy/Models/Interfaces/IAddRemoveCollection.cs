namespace PracticeForJudge.Models.Interfaces
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
