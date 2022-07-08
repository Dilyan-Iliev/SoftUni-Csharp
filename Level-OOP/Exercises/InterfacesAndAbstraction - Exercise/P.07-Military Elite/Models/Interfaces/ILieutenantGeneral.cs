using System.Collections.Generic;

namespace LocalPractice.Models.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        List<IPrivate> Privates { get; set; }
    }
}
