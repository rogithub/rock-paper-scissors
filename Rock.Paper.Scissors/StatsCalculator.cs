using System;
using System.Linq;
using System.Collections.Generic;

namespace Rock.Paper.Scissors
{
    public class Stats 
    {
        public int TotalRounds { get; set; }
        public int UserWinsCount { get; set; }
        public double UserWinsPercent { get; set; }
        public int ComputerWinsCount { get; set; }
        public double ComputerWinsPercent { get; set; }
        public int TiesCount { get; set; }
        public double TiesPercent { get; set; }
    }

    public interface IStatsCalculator<T>
    {
        Stats Calculate (IList<T> list);
    }

    public class StatsCalculator: IStatsCalculator<Round>
    {
        public double Percentage(int total, int n) 
        {
            return total == 0 ? 0 : (n * 100) / total;
        }        

        public Stats Calculate (IList<Round> list)
        {
            var arr = list.ToArray();
            var userWins = arr.Count(round => round.UserWins);
            var ties = arr.Count(round => round.IsTie);
            var computerWins = arr.Count(round => !round.IsTie && !round.UserWins);

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
