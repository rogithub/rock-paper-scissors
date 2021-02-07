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
}
