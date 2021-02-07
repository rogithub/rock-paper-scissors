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
            var arr = list.ToArray();
            var userWins = arr.Count(round => round.UserWins);
            var ties = arr.Count(round => round.IsTie);
            var computerWins = arr.Count(round => round.ComputerWins);

            return new Stats()
            {
                TotalRounds = arr.Length,
                ComputerWinsCount = computerWins,
                ComputerWinsPercent = Percentage(arr.Length, computerWins),
                UserWinsCount = userWins,
                UserWinsPercent = Percentage(arr.Length, userWins),
                TiesCount = ties,
                TiesPercent = Percentage(arr.Length, ties)               
            };
        }
    }
}
