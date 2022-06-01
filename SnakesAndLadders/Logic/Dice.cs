using System;

namespace SnakesAndLadders.Logic
{
    public class Dice
    {
        private readonly Random random;
        public Dice()
        {
            random = new Random();
        }
        public int RollDice() => random.Next(1, 7);
    }
}
