using P._07_Military_Elite.Enums;

namespace P._07_Military_Elite.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; set; }
    }
}
