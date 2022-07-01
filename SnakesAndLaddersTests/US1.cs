using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Logic;
using SnakesAndLadders.Model;
using System.Collections.Generic;

namespace SnakesAndLaddersTests
{
    [TestClass]
    public class US1
    {
        //As a player
        //I want to be able to move my token
        //So that I can get closer to the goal

        private readonly Player _player;
        private readonly GameBoard _gameBoard;

        public US1()
        {
            _player = new Player("Jugador 1");
            List<Player> players = new List<Player> { _player };
            var dice = new SimulatedDice(new List<int> { 3, 4});
            var gameObjects = new List<GameObject>();
            _gameBoard = new GameBoard(100, players, dice, gameObjects);
            _gameBoard.PlacePlayersIntoBoard();
        }


        [TestMethod]
        public void UAT1()
        {
            //Given the game is started
            //When the token is placed on the board
            //Then the token is on square 1
            
            var position = _player.GetTokenPosition();

            Assert.AreEqual(1, position);
        }

        [TestMethod]
        public void UAT2()
        {
            //Given the token is on square 1
            //When the token is moved 3 spaces
            //Then the token is on square 4
            
            _gameBoard.PlayTurn();

            var position = _player.GetTokenPosition();

            Assert.AreEqual(4, position);
        }

        [TestMethod]
        public void UAT3()
        {
            //Given the token is on square 1
            //When the token is moved 3 spaces
            //And then it is moved 4 spaces
            //Then the token is on square 8            

            _gameBoard.PlayTurn();
            _gameBoard.PlayTurn();

            var position = _player.GetTokenPosition();

            Assert.AreEqual(8, position);
        }        
    }
}
