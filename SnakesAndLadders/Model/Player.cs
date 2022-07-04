using System;
using System.Collections.Generic;

namespace SnakesAndLadders.Model
{
    public class Player
    {
        public string Name { get; }
        public IList<string> Actions { get; }
        public Guid Id { get; }

        private int TokenPosition;

        public Player(string name)
        {
            Name = name;
            Actions = new List<string>() { Constants.Actions.WaitStart };
            Id = Guid.NewGuid();
        }

        public Player(string name, int startPosition)
        {
            Name = name;
            TokenPosition = startPosition;
            Actions = new List<string>() { Constants.Actions.WaitStart };
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
