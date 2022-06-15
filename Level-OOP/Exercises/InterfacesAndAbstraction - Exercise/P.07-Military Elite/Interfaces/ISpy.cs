using System;
using System.Collections.Generic;
using System.Text;

namespace P._07_Military_Elite.Interfaces
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; set; }
    }
}
