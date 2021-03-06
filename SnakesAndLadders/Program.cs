using Microsoft.Extensions.Configuration;
using SnakesAndLadders.Logic;
using SnakesAndLadders.Model;
using SnakesAndLadders.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Obtener configuraciones iniciales
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            var gameSettings = new GameSettings();
            config.GetSection("GameSettings").Bind(gameSettings);

            //Preguntar por los jugadores
            var playerNames = AskForPlayers(gameSettings.MinPlayers, gameSettings.MaxPlayers);

            //Configurar juego
            (var gameBoard, var players) = ConfigureGame(playerNames, gameSettings.Squares);

            //Iniciar juego
            Init(gameBoard, players, gameSettings.Squares);

            Console.ReadKey();
        }


        private static (GameBoard, IList<Player>) ConfigureGame(IList<string> playerNames, int totalSquares)
        {
            var players = playerNames.Select(player => new Player(player)).ToList();
            var dice = new Dice();

            var gameObject = new List<GameObject>();
            gameObject.AddRange(FillBoardWithSnakes());
            gameObject.AddRange(FillBoardWithLadders());

            return (new GameBoard(totalSquares, players, dice, gameObject), players);
        }

        private static void Init(GameBoard gameBoard, IList<Player> players, int goalSquare)
        {
            gameBoard.PlacePlayersIntoBoard();

            do
            {
                Console.Clear();
                ScoreBoard.PrintScoreBoard(players, goalSquare);
                Console.WriteLine();
                Console.WriteLine($"Presione una tecla para lanzar el dado");
                //Console.ReadKey();

                gameBoard.PlayTurn();

                ScoreBoard.MoveToken();
            }
            while (!gameBoard.IsOver());

            Console.Clear();
            Console.WriteLine($"JUGADOR {gameBoard.Winner().Name} ES EL GANADOR!!!");
            ScoreBoard.PrintScoreBoard(players, goalSquare);
            Console.WriteLine();
            Console.WriteLine(string.Join(Environment.NewLine, gameBoard.Winner().Actions));

        }


        private static IEnumerable<GameObject> FillBoardWithSnakes()
        {
            var snakes = new List<(int, int)>{
                (16, 6),(46, 25),(49, 11),(62, 19),
                (64, 60),(74, 53),(89, 68),(92, 88),
                (95, 75),(99, 80)
            };

            return snakes.Select(x => new GameObject(x.Item1, x.Item2, GameObjectType.Snake));
        }

        private static IEnumerable<GameObject> FillBoardWithLadders()
        {
            var ladders = new List<(int, int)>
            {
                (2, 38),(7, 14),(8, 31),(15, 26),
                (21, 42),(28, 84),(36, 44),(51, 67),
                (71, 91),(78, 98),(87, 94),
            };

            return ladders.Select(x => new GameObject(x.Item1, x.Item2, GameObjectType.Ladder));
        }


        private static IList<string> AskForPlayers(int min, int max)
        {
            bool validNumber;
            int value;
            do
            {
                Console.WriteLine("Ingrese el número de jugadores, entre {0} y {1}", min, max);
                validNumber = int.TryParse(Console.ReadLine(), out value);
            }
            while (!validNumber || value < min || value > max);

            var names = new List<string>();

            for (int i = 0; i < value; i++)
            {
                string name;
                bool validName;
                do
                {
                    Console.WriteLine("Ingrese el nombre del jugador {0}", i + 1);
                    name = Console.ReadLine().Trim();
                    validName = !string.IsNullOrEmpty(name) && !names.Any(x => x.ToUpper() == name.ToUpper());
                }
                while (!validName);
                names.Add(name);
            }

            return names;
        }
    }
}
