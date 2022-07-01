using System;

namespace SnakesAndLadders.Model
{
    public class GameObject
    {
        readonly int _from, _to;
        readonly GameObjectType _type;

        public GameObject(int from, int to, GameObjectType type)
        {
            _from = from;
            _to = to;
            _type = type;
        }

        public bool IsInitialSquare(int position) =>
            _from.Equals(position);

        public int To() =>
            _to;

        public string GetGameObjectAction() => _type switch
        {
            GameObjectType.Snake => Constants.Actions.MoveToBottomOfSnake,
            GameObjectType.Ladder => Constants.Actions.MoveToTopOfLadder,
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public enum GameObjectType
    {
        Snake,
        Ladder
    }
}
