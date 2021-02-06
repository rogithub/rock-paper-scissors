using System;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public interface IRoundGame<T>
    {
        void Add(T round);
        IList<T> Rounds { get; }
    }
}
