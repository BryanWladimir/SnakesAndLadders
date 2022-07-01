using System;
using System.Collections.Generic;

namespace SnakesAndLadders.Logic
{
    public interface IDice
    {
        public int RollDice();
    }

    public class SimulatedDice : IDice
    {
        readonly List<int> _diceResults;
        int _currentPosition = 0;
        public SimulatedDice(List<int> diceResults)
        {
            _diceResults = diceResults;
        }

        public int RollDice()
        {
            var result = _diceResults[_currentPosition % _diceResults.Count];
            _currentPosition++;
            return result;
        }
    }
    public class Dice : IDice
    {
        private readonly Random random;
        public Dice()
        {
            random = new Random();
        }
        public int RollDice() => random.Next(1, 7);
    }
}
