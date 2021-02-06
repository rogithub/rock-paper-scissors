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
            if (rounds.Count < 2) return (Move)_rnd.Next(0, 2);

            // if last two user choices are repeated (and won or tie)
            // increase chance to win by giving more points
            // to beating move
            var prev = rounds[rounds.Count - 2];
            var r = rounds[rounds.Count - 1];

            if ((r.UserMove == prev.UserMove) && !r.ComputerWins && !prev.ComputerWins)
            {
                return BeatMe(r.UserMove);
            }

            return (Move)_rnd.Next(0, 2);
        }
    }
}
