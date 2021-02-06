using System;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public class Game : IRoundGame<Move, Round>
    {
        public Dictionary<Move, int> WonsCount { get; private set; }
        public IList<Round> Rounds { get; private set; }
        private IMovePickerStrategy<Move, Round> Strategy { get; set; }

        public Game(IMovePickerStrategy<Move, Round> strategy)
        {
            this.Strategy = strategy;
            this.Rounds = new List<Round>();
            this.WonsCount = new Dictionary<Move, int>()
            {
                [Move.Rock] = 0,
                [Move.Paper] = 0,
                [Move.Scissors] = 0
            };
        }

        public Round AddUserMove(Move move)
        {
            Round r = new Round();
            r.UserMove = move;
            r.ComputerMove = Strategy.GetNextMove(this.Rounds, this.WonsCount);
            if (!r.IsTie)
            {
                WonsCount[r.UserWins ? r.UserMove : r.ComputerMove] += 1;
            }

            this.Rounds.Add(r);

            return r;
        }
    }
}
