using System;
using System.Linq;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public class HigherWinRateStrategy : IMovePickerStrategy<Move, Round>
    {
        private Random _rnd = new Random();

        private Move BeatMe(Move m)
        {
            return m switch
            {
                Move.Rock => Move.Paper,
                Move.Paper => Move.Scissors,
                Move.Scissors => Move.Rock,
                _ => (Move)_rnd.Next(0, 2)
            };
        }

        public Move GetNextMove(IList<Round> rounds)
        {
            // first time return random
            if (rounds.Count == 0) return (Move)_rnd.Next(0, 2);

            Dictionary<Move, int> wonsCount = new Dictionary<Move, int>()
            {
                [Move.Rock] = 0,
                [Move.Paper] = 0,
                [Move.Scissors] = 0
            };

            // beat each tie and sum to wons
            rounds.ToList().ForEach(r =>
            {
                if (!r.ComputerWins)
                {
                    var move = BeatMe(r.UserMove);
                    wonsCount[move] += 1;
                    return;
                }
            });

            // all won same times return random
            if (wonsCount[Move.Rock] == wonsCount[Move.Paper] && wonsCount[Move.Paper] == wonsCount[Move.Scissors])
                return (Move)_rnd.Next(0, 2);

            var keyOfMaxValue = wonsCount.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return keyOfMaxValue;
        }
    }
}
