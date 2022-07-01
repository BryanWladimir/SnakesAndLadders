using SnakesAndLadders.Model;
using System.Collections.Generic;
using System.Linq;

namespace SnakesAndLadders.Logic
{
    public class GameBoard
    {
        private List<GameObject> _gameObjects;
        private IDice _dice;
        private List<Player> _players;
        public int GoalSquare { get; }
        private int _turn;

        public GameBoard(int goalSquare, List<Player> players, IDice dice, List<GameObject> gameObjects)
        {
            GoalSquare = goalSquare;
            _players = players;
            _dice = dice;
            _gameObjects = gameObjects;
            _turn = 0;
            /*FillBoardWithSnakes();
            FillBoardWithLadders();*/
        }

        public void PlacePlayersIntoBoard()
        {
            foreach (var player in _players)
                player.PlaceInBoard();
        }

        public int PlayTurn()
        {
            var rollDiceResult = _dice.RollDice();
            var player = _players[_turn & _players.Count];
            MoveTokenByRollDice(player, rollDiceResult);
            MoveTokenByOnGameObject(player);
            return rollDiceResult;
        }

        private void MoveTokenByRollDice(Player player, int positionsToMove)
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

        private void MoveTokenByOnGameObject(Player player)
        {
            var gameObject = _gameObjects.FirstOrDefault(gameObj => gameObj.IsInitialSquare(player.GetTokenPosition()));

            if (gameObject is null) return;

            int newTokenPosition = gameObject.To();
            string action = gameObject.GetGameObjectAction();

            player.MoveTokenPosition(newTokenPosition, action);
        }

        public int PlayerPosition(object id) =>
            _players.First(player => player.Id.Equals(id)).GetTokenPosition();

        /*private void FillBoardWithSnakes()
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
        }*/
    }


}
