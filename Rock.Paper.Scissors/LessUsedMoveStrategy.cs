using System;
using System.Linq;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public class LessUsedMoveStrategy
    {
        private Random _rnd = new Random();

        public Move GetNextMove(IList<Round> rounds)
        {
            // first time return random
            if (rounds.Count == 0) return (Move)_rnd.Next(0, 2);

            var lessUsed = rounds.GroupBy(r => r.UserMove)
                        .Select(group => new
                        {
                            Move = group.Key,
                            Count = group.Count()
                        })
                        .OrderByDescending(x => x.Count)
                        .First();

            return lessUsed.Move;
        }
    }
}
