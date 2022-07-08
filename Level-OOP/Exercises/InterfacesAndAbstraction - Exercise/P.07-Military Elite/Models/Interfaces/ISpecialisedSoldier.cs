using LocalPractice.Models.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalPractice.Models.Interfaces
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; set; }
    }
}
