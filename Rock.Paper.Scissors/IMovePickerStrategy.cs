using System;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public interface IMovePickerStrategy<TMove, TRound>
    {
        TMove GetNextMove(IList<TRound> rounds, Dictionary<TMove, int> wonsCount);
    }
}
