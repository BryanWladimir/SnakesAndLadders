using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakesAndLadders.Logic;
using SnakesAndLadders.Model;
using System.Collections.Generic;

namespace SnakesAndLaddersTests
{
    [TestClass]
    public class US2
    {
        //As a player
        //I want to be able to win the game
        //So that I can gloat to everyone around

        private readonly Player _player;
        private readonly List<GameObject> _gameObjects;
        private readonly List<Player> _players;

        public US2()
        {
            _player = new Player("Jugador 1", 97);
            _players = new List<Player> { _player };
            _gameObjects = new List<GameObject>();

        }


        [TestMethod]
        public void UAT1()
        {
            //Given the token is on square 97
            //When the token is moved 3 spaces
            //Then the token is on square 100
            //And the player has won the game

            var dice = new SimulatedDice(new List<int> { 3 });
            var gameBoard = new GameBoard(100, _players, dice, _gameObjects);

            gameBoard.PlayTurn();

            var position = _player.GetTokenPosition();
            var winner = gameBoard.Winner();

            Assert.AreEqual(100, position);
            Assert.AreEqual(_player, winner);
        }

        [TestMethod]
        public void UAT2()
        {
            //Given the token is on square 97
            //When the token is moved 4 spaces
            //Then the token is on square 97
            //And the player has not won the game

            var dice = new SimulatedDice(new List<int> { 4 });
            var gameBoard = new GameBoard(100, _players, dice, _gameObjects);

            gameBoard.PlayTurn();

            var position = _player.GetTokenPosition();
            var winner = gameBoard.Winner();

            Assert.AreEqual(97, position);
            Assert.AreNotEqual(_player, winner);
        }

    }
}
