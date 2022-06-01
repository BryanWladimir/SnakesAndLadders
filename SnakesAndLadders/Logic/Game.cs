using SnakesAndLadders.Model;
using SnakesAndLadders.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders.Logic
{
    public class Game
    {
        private readonly IList<Player> Players;
        private readonly int GoalSquare;
        private readonly Dice dice;
        private readonly GameBoard gameBoard;

        public Game(IList<string> playerNames, int totalSquares)
        {
            Players = playerNames.Select(player => new Player(player)).ToList();
            GoalSquare = totalSquares;
            dice = new Dice();
            gameBoard = new GameBoard(GoalSquare);
        }

        public void Init()
        {
            int turn = 1;
            gameBoard.PlacePlayersIntoBoard(Players);

            do
            {
                foreach (var player in Players)
                {

                    Console.Clear();
                    Console.WriteLine($"Turno {turn} - Jugador {player.Name}");
                    ScoreBoard.PrintScoreBoard(Players, GoalSquare);
                    Console.WriteLine();
                    Console.WriteLine($"Presione una tecla para lanzar el dado");
                    Console.ReadKey();

                    var rollDiceResult = dice.RollDice();

                    Console.WriteLine("Jugador {0} ha lanzado un {1} {2}", player.Name, rollDiceResult, Environment.NewLine);

                    gameBoard.PlayTurn(player, rollDiceResult);

                    ScoreBoard.MoveToken();

                    if (player.IsWinner)
                        break;
                }
                turn++;
            }
            while (!Players.Any(player => player.IsWinner));


            Console.Clear();
            Console.WriteLine($"JUGADOR {Players.First(player => player.IsWinner).Name} ES EL GANADOR!!!");
            ScoreBoard.PrintScoreBoard(Players, GoalSquare);
        }
    }
}
