using System;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public interface IGame<TMove, TRound>
    {
        TRound AddUserMove(TMove move);
        IList<TRound> Rounds { get; }
        void Reset();
    }
}
