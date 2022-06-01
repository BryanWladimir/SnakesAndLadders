using SnakesAndLadders.Model;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders.Logic
{
    public class GameBoard
    {
        private readonly List<GameObject> gameObjects = new List<GameObject>();
        public int GoalSquare { get; }

        public GameBoard(int goalSquare)
        {
            GoalSquare = goalSquare;
            FillBoardWithSnakes();
            FillBoardWithLadders();
        }

        public void PlacePlayersIntoBoard(IList<Player> players)
        {
            foreach (var player in players)
                player.PlaceInBoard();
        }

        public void PlayTurn(Player player, int rollDiceResult)
        {
            MoveTokenByRollDice(player, rollDiceResult);
            MoveTokenByOnGameObject(player);
        }

        public void MoveTokenByRollDice(Player player, int positionsToMove)
        {
            var newPlayerPosition = player.GetTokenPosition() + positionsToMove;

            if (newPlayerPosition < GoalSquare)
            {
                player.MoveTokenPosition(newPlayerPosition, Constants.Actions.Move);
                return;
            }

            if (newPlayerPosition > GoalSquare)
            {
                player.MoveTokenPosition(player.GetTokenPosition(), Constants.Actions.DontMove);
                return;
            }

            player.MoveTokenPosition(newPlayerPosition, Constants.Actions.ReachGoal);
            player.IsWinner = true;
        }

        public void MoveTokenByOnGameObject(Player player)
        {
            var gameObject = gameObjects.FirstOrDefault(gameObj => gameObj.GetInitialSquare() == player.GetTokenPosition());

            if (gameObject is null) return;

            (int newTokenPosition, string action) = gameObject.MoveTokenByGameObject();

            player.MoveTokenPosition(newTokenPosition, action);
        }

        private void FillBoardWithSnakes()
        {
            var snakes = new List<Snake>
            {
                new Snake(16, 6),
                new Snake(46, 25),
                new Snake(49, 11),
                new Snake(62, 19),
                new Snake(64, 60),
                new Snake(74, 53),
                new Snake(89, 68),
                new Snake(92, 88),
                new Snake(95, 75),
                new Snake(99, 80)
            };

            gameObjects.AddRange(snakes);
        }

        private void FillBoardWithLadders()
        {
            var ladders = new List<Ladder>
            {
                new Ladder(2, 38),
                new Ladder(7, 14),
                new Ladder(8, 31),
                new Ladder(15, 26),
                new Ladder(21, 42),
                new Ladder(28, 84),
                new Ladder(36, 44),
                new Ladder(51, 67),
                new Ladder(71, 91),
                new Ladder(78, 98),
                new Ladder(87, 94),
            };

            gameObjects.AddRange(ladders);
        }
    }


}
