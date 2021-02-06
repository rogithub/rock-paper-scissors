using System;
using System.Linq;
using Rock.Paper.Scissors;

namespace ConsoleApp
{
    class Program
    {
        private static bool Validate(char strNumber, out int iMove)
        {
            iMove = -1;
            if
            (
                int.TryParse(strNumber.ToString(), out iMove) == false ||
                iMove < 0 ||
                iMove > 2
            )
            {
                return false;
            }
            return true;
        }

        private static void PrintResult(Round r)
        {
            string winner = r.IsTie ? "Tie" : r.UserWins ? "User Wins" : "Computer Wins";
            if (r.UserWins) Console.ForegroundColor = ConsoleColor.Green;
            if (!r.UserWins && !r.IsTie) Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{winner}], User: {r.UserMove}, Computer: {r.ComputerMove}");
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            var strategy = new HigherWinRateStrategy();
            var game = new Game(strategy);

            char strMove = '0';
            while (strMove != 'q')
            {
                Console.Clear();
                Console.WriteLine("Pick a number [0 Rock, 1 Paper, 2 Scissors, q Quit]:");
                strMove = Console.ReadKey(true).KeyChar;
                int iMove = 0;

                if (Validate(strMove, out iMove) == false)
                {
                    if (strMove != 'q') Console.WriteLine("Input not valid");
                    continue;
                }

                Move userMove = (Move)iMove;
                var r = game.AddUserMove(userMove);
                PrintResult(r);
                Console.ReadKey();
            }

            Func<int, int, double> percentage = (total, n) => total == 0 ? 0 : (n * 100) / total;
            Console.WriteLine("Results \t Times \t Percent");
            Console.WriteLine("===============================");
            var arr = game.Rounds.ToArray();
            var userWins = arr.Count(round => round.UserWins);
            var ties = arr.Count(round => round.IsTie);
            var computerWins = arr.Count(round => !round.IsTie && !round.UserWins);

            Console.WriteLine($"Total Rounds    \t{arr.Length}");
            Console.WriteLine($"User Wins       \t{userWins} \t{percentage(arr.Length, userWins)}%");
            Console.WriteLine($"Computer Wins   \t{computerWins} \t{percentage(arr.Length, computerWins)}%");
            Console.WriteLine($"Ties            \t{ties} \t{percentage(arr.Length, ties)}%");
        }
    }
}
