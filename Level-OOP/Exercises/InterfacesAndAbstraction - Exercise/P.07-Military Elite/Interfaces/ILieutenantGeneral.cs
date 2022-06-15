using System.Collections.Generic;

namespace P._07_Military_Elite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        List<IPrivate> Privates { get; set; } 
    }
}
