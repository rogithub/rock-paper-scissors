using System;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public class Game<T> : IRoundGame<T>
    {
        public IList<T> Rounds { get; private set; }

        public Game()
        {
            this.Rounds = new List<T>();
        }

        public void Add(T round)
        {
            this.Rounds.Add(round);
        }
    }
}
