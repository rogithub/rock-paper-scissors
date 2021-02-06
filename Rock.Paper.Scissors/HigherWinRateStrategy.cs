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

            Dictionary<Move, int> moveWeight = new Dictionary<Move, int>()
            {
                [Move.Rock] = 0,
                [Move.Paper] = 0,
                [Move.Scissors] = 0
            };

            var arr = rounds.ToArray();

            // beat each round and sum
            for (int i = 0; i < arr.Length; i++)
            {
                var r = arr[i];
                var winningMove = r.ComputerWins ?
                                     r.ComputerMove :                // computer wins so is ok
                                     BeatMe(r.UserMove);             // beat either user or tie result

                moveWeight[winningMove] += 1;

                // if last two user choices are repeated (and won or tie)
                // increase chance to win by giving more points
                // to beating move
                if (i > 0)
                {
                    var prev = arr[i - 1];

                    if (r.UserMove == prev.UserMove && (r.UserWins || r.IsTie) && (prev.UserWins || prev.IsTie))
                    {
                        moveWeight[BeatMe(r.UserMove)] += 1;
                    }
                }
            }


            // all won same times return random
            if (moveWeight[Move.Rock] == moveWeight[Move.Paper] && moveWeight[Move.Paper] == moveWeight[Move.Scissors])
                return (Move)_rnd.Next(0, 2);

            var keyOfMaxValue = moveWeight.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return keyOfMaxValue;
        }
    }
}
