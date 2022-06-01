using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using SnakesAndLadders.Model;

namespace SnakesAndLadders.View
{
    public static class ScoreBoard
    {
        static readonly int tableWidth = 100;
        public static void PrintScoreBoard(IList<Player> players, int totalSquare)
        {
            var scoreBoard = new string[]
            {
                Environment.NewLine,
                Line(),
                Row("Jugador", "Posición", "Acción"),
                Line(),
                string.Join(Environment.NewLine, players.Select(x => Row(x.Name, $"{x.GetTokenPosition()}/{totalSquare}", x.Actions.LastOrDefault()))),
                Line(),
                Environment.NewLine
            };
            Console.WriteLine(string.Join(Environment.NewLine, scoreBoard));
        }

        public static void MoveToken()
        {
            Console.Write($"{Environment.NewLine}Moviendo ficha... ");
            using (var progress = new ProgressBar())
            {
                for (int i = 0; i <= 100; i+=2)
                {
                    progress.Report((double)i / 100);
                    Thread.Sleep(1);
                }
            }
            Console.WriteLine("Hecho.");
            Thread.Sleep(200);
        }

        public static string Line() => 
            new string('-', tableWidth);        

        public static string Row(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            var row = new StringBuilder("|");

            foreach (string column in columns)            
                row.Append($"{AlignCenter(column, width)} |");

            return row.ToString();
        }

        public static string AlignCenter(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            return string.IsNullOrEmpty(text)
                ? new string(' ', width)
                : text.PadRight(width - (width - text.Length) / 2).PadLeft(width);            
        }
    }
}
