
namespace SnakesAndLadders.Model
{
    public abstract class GameObject
    {
        protected int StartSquare;
        protected int EndSquare;

        public abstract int GetInitialSquare();
        public abstract (int, string) MoveTokenByGameObject();
    }

    public class Snake : GameObject
    {
        public Snake(int start, int end)
        {
            StartSquare = start;
            EndSquare = end;
        }

        public override int GetInitialSquare()
            => StartSquare;


        public override (int, string) MoveTokenByGameObject()
            => (EndSquare, Constants.Actions.MoveToBottomOfSnake);
    }

    public class Ladder : GameObject
    {
        public Ladder(int start, int end)
        {
            StartSquare = start;
            EndSquare = end;
        }

        public override int GetInitialSquare()
            => StartSquare;


        public override (int, string) MoveTokenByGameObject()
            => (EndSquare, Constants.Actions.MoveToTopOfLadder);
    }
}
