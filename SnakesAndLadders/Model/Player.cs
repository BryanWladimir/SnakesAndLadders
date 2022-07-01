using System;
using System.Collections.Generic;

namespace SnakesAndLadders.Model
{
    public class Player
    {
        public string Name { get; }
        public IList<string> Actions { get; }
        public bool IsWinner { get; set; }

        private int TokenPosition;
        public Guid Id { get; }

        public Player(string name)
        {
            Name = name;
            Actions = new List<string>() { Constants.Actions.WaitStart };
            IsWinner = false;
            Id = Guid.NewGuid();
        }

        public Player(string name, int startPosition)
        {
            Name = name;
            TokenPosition = startPosition;
            Actions = new List<string>() { Constants.Actions.WaitStart };
            IsWinner = false;
        }

        public void PlaceInBoard()
        {
            TokenPosition = 1;
        }

        public void MoveTokenPosition(int newTokenPosition, string action)
        {
            TokenPosition = newTokenPosition;
            Actions.Add(string.Format(action, newTokenPosition));
        }

        public int GetTokenPosition() => TokenPosition;
    }
}
