using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Logic;
using SnakesAndLadders.Model;

namespace SnakesAndLaddersTests
{
    [TestClass]
    public class US2
    {
        //As a player
        //I want to be able to win the game
        //So that I can gloat to everyone around

        private readonly Player _player;
        private readonly GameBoard _gameBoard;

        public US2()
        {
            _player = new Player("Jugador 1", 97);
            _gameBoard = new GameBoard(100);
        }


        [TestMethod]
        public void UAT1()
        {
            //Given the token is on square 97
            //When the token is moved 3 spaces
            //Then the token is on square 100
            //And the player has won the game

            var rollDiceResult = 3;

            _gameBoard.MoveTokenByRollDice(_player, rollDiceResult);

            var position = _player.GetTokenPosition();

            var isWinner = _player.IsWinner;

            Assert.AreEqual(100, position);
            Assert.IsTrue(isWinner);
        }

        [TestMethod]
        public void UAT2()
        {
            //Given the token is on square 97
            //When the token is moved 4 spaces
            //Then the token is on square 97
            //And the player has not won the game

            var rollDiceResult = 4;

            _gameBoard.MoveTokenByRollDice(_player, rollDiceResult);

            var position = _player.GetTokenPosition();

            var isWinner = _player.IsWinner;

            Assert.AreEqual(97, position);
            Assert.IsFalse(isWinner);
        }
        
    }
}
