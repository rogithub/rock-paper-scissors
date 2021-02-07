using System;
using System.Linq;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public interface IStatsCalculator<T>
    {
        Stats Calculate (IList<T> list);
    }
}
