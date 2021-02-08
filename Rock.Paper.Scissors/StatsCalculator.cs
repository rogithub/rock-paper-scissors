using System;
using System.Linq;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public class StatsCalculator: IStatsCalculator<Round>
    {
        private double Percentage(int total, int n) 
        {
            return total == 0 ? 0 : (n * 100) / total;
        }        

        public Stats Calculate (IList<Round> list)
        {
            var userWins = list.Count(round => round.UserWins);
            var ties = list.Count(round => round.IsTie);
            var computerWins = list.Count(round => round.ComputerWins);

            return new Stats()
            {
                TotalRounds = list.Count,
                ComputerWinsCount = computerWins,
                ComputerWinsPercent = Percentage(list.Count, computerWins),
                UserWinsCount = userWins,
                UserWinsPercent = Percentage(list.Count, userWins),
                TiesCount = ties,
                TiesPercent = Percentage(list.Count, ties)               
            };
        }
    }
}
