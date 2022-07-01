using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Logic;
using SnakesAndLadders.Model;
using System.Collections.Generic;

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
        private readonly IDice _dice;

        public US3()
        {
            _player = new Player("Jugador 1");
            _dice = new Dice();
            List<Player> players = new List<Player> { _player };
            var gameObjects = new List<GameObject>();
            _gameBoard = new GameBoard(100, players, _dice, gameObjects);
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
            //Given the player rolls a n
            //When they move their token
            //Then the token should move n spaces

            var initialPosition = _player.GetTokenPosition();            
            
            var rollDiceResult = _gameBoard.PlayTurn();

            var endPosition = _player.GetTokenPosition();

            var spacedMoved = endPosition - initialPosition;

            Assert.AreEqual(rollDiceResult, spacedMoved);
        }

    }
}
