
namespace SnakesAndLadders.Model
{
    public static class Constants
    {
        public static class Actions
        {
            public const string WaitStart = "Espera inicio";
            public const string Move = "Mueve ficha a {0}";
            public const string DontMove = "No mueve ficha";
            public const string MoveToTopOfLadder = "Sube ficha por escalera a {0}";
            public const string MoveToBottomOfSnake = "Baja ficha por serpiente a {0}";
            public const string ReachGoal = "Llega meta";
        }

        public static class Errors
        {
            public const string GameOver = "El juego ya ha terminado";
        }
    }
}
