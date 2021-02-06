using System;
using System.Linq;
using Rock.Paper.Scissors;

namespace ConsoleApp
{
    class Program
    {
        static IMovePickerStrategy<Move, Round> _strategy = new CheckUserLastMovesStrategy();
        static Game _game = new Game(_strategy);

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
            string op = r.IsTie ? "==" : r.UserWins ? ">" : "<";

            if (r.UserWins) Console.ForegroundColor = ConsoleColor.Green;
            if (!r.UserWins && !r.IsTie) Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"{_game.Rounds.IndexOf(r)} | {winner.PadRight(13, ' ')} | User: {r.UserMove} {op} Computer: {r.ComputerMove}");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
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
                var r = _game.AddUserMove(userMove);
                PrintResult(r);
                Console.ReadKey();
            }
            Console.Clear();

            Func<int, int, double> percentage = (total, n) => total == 0 ? 0 : (n * 100) / total;

            Console.WriteLine("================================================");
            Console.WriteLine("Results");
            Console.WriteLine("================================================");
            var arr = _game.Rounds.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                PrintResult(arr[i]);
            }


            Console.WriteLine("================================================");

            var userWins = arr.Count(round => round.UserWins);
            var ties = arr.Count(round => round.IsTie);
            var computerWins = arr.Count(round => !round.IsTie && !round.UserWins);

            Console.WriteLine($"Total Rounds    {arr.Length}");
            Console.WriteLine($"User Wins       {userWins} ({percentage(arr.Length, userWins)}%)");
            Console.WriteLine($"Computer Wins   {computerWins} ({percentage(arr.Length, computerWins)}%)");
            Console.WriteLine($"Ties            {ties} ({percentage(arr.Length, ties)}%)");
            Console.WriteLine("================================================");
        }
    }
}
