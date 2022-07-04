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
        private int _goalSquare;
        private int _turn;

        public GameBoard(int goalSquare, List<Player> players, IDice dice, List<GameObject> gameObjects)
        {
            _goalSquare = goalSquare;
            _players = players;
            _dice = dice;
            _gameObjects = gameObjects;
            _turn = 0;
        }

        public void PlacePlayersIntoBoard()
        {
            foreach (var player in _players)
                player.PlaceInBoard();
        }

        public int PlayTurn()
        {
            var rollDiceResult = _dice.RollDice();
            var player = _players[_turn % _players.Count];
            MoveTokenByRollDice(player, rollDiceResult);
            MoveTokenByOnGameObject(player);
            _turn++;
            return rollDiceResult;
        }

        private void MoveTokenByRollDice(Player player, int positionsToMove)
        {
            var newPlayerPosition = player.GetTokenPosition() + positionsToMove;

            if (newPlayerPosition < _goalSquare)
            {
                player.MoveTokenPosition(newPlayerPosition, Constants.Actions.Move);
                return;
            }

            if (newPlayerPosition > _goalSquare)
            {
                player.MoveTokenPosition(player.GetTokenPosition(), Constants.Actions.DontMove);
                return;
            }

            player.MoveTokenPosition(newPlayerPosition, Constants.Actions.ReachGoal);
            
        }

        private void MoveTokenByOnGameObject(Player player)
        {
            var gameObject = _gameObjects.FirstOrDefault(gameObj => gameObj.IsInitialSquare(player.GetTokenPosition()));

            if (gameObject is null) return;

            int newTokenPosition = gameObject.To();
            string action = gameObject.GetGameObjectAction();

            player.MoveTokenPosition(newTokenPosition, action);
        }

        public Player Winner() =>
            _players.FirstOrDefault(player => player.GetTokenPosition() == _goalSquare);

        public bool IsOver() =>
            Winner() != null;

        
    }


}
