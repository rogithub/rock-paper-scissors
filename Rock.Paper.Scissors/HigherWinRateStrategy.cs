using System;
using System.Linq;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public class HigherWinRateStrategy : IMovePickerStrategy<Move, Round>
    {
        private Random _rnd = new Random();

        public Move GetNextMove(IList<Round> rounds, Dictionary<Move, int> wonsCount)
        {
            // first time return random
            if (rounds.Count == 0) return (Move)_rnd.Next(0, 2);

            // all won same times return random
            if (wonsCount[Move.Rock] == wonsCount[Move.Paper] && wonsCount[Move.Paper] == wonsCount[Move.Scissors])
                return (Move)_rnd.Next(0, 2);

            var keyOfMaxValue = wonsCount.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return keyOfMaxValue;
        }
    }
}
