using System;

namespace Rock.Paper.Scissors
{
    public class Round : IRound<Move>
    {
        public Round()
        {
            this.TimeStamp = DateTime.Now;
        }
        public Move UserMove { get; set; }
        public Move ComputerMove { get; set; }
        public DateTime TimeStamp { get; set; }

        public bool UserWins
        {
            get
            {
                return UserMove switch
                {
                    Move.Rock => ComputerMove == Move.Scissors,
                    Move.Paper => ComputerMove == Move.Rock,
                    Move.Scissors => ComputerMove == Move.Paper,
                    _ => false
                };
            }
        }

        public bool ComputerWins
        {
            get
            {
                return !IsTie && !UserWins;
            }
        }
        public bool IsTie
        {
            get
            {
                return ComputerMove == UserMove;
            }
        }
    }
}
