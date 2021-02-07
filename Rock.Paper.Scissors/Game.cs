using System;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public class Game : IGame<Move, Round>
    {
        public IList<Round> Rounds { get; private set; }
        private IMovePickerStrategy<Move, Round> Strategy { get; set; }

        public Game(IMovePickerStrategy<Move, Round> strategy)
        {
            this.Strategy = strategy;
            this.Reset();
        }

        public Round AddUserMove(Move user)
        {
            var computer = Strategy.GetNextMove(this.Rounds);
            var round = new Round(user, computer);
            this.Rounds.Add(round);
            return round;
        }

        public void Reset()
        {
            this.Rounds = new List<Round>();
        }

    }
}
