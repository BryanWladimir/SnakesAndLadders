using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Logic;
using SnakesAndLadders.Model;

namespace SnakesAndLaddersTests
{
    [TestClass]
    public class US3
    {
        //As a player
        //I want to move my token based on the roll of a die
        //So that there is an element of chance in the game

        private readonly Player _player;
        private readonly GameBoard _gameBoard;
        private readonly Dice _dice;

        public US3()
        {
            _player = new Player("Jugador 1");
            _gameBoard = new GameBoard(100);
            _dice = new Dice();
        }


        [TestMethod]
        public void UAT1()
        {
            //Given the game is started
            //When the player rolls a die
            //Then the result should be between 1 - 6 inclusive

            var rollDiceResult = _dice.RollDice();

            Assert.IsTrue(rollDiceResult >= 1 && rollDiceResult <= 6);
        }

        [TestMethod]
        public void UAT2()
        {
            //Given the player rolls a 4
            //When they move their token
            //Then the token should move 4 spaces

            //var rollDiceResult = _dice.RollDice();
            var rollDiceResult = 4;

            var initialPosition = _player.GetTokenPosition();

            _gameBoard.MoveTokenByRollDice(_player, rollDiceResult);

            var endPosition = _player.GetTokenPosition();

            var spacedMoved = endPosition - initialPosition;

            Assert.AreEqual(rollDiceResult, spacedMoved);
        }

    }
}
