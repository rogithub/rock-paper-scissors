using System;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public interface IRound<TMove>
    {
        TMove UserMove { get; set; }
        TMove ComputerMove { get; set; }
        DateTime TimeStamp { get; set; }
    }
}
