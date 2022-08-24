using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    public class Doubler
    {
        private const int START_MAX = 25;
        private const int GOAL_MAX = 200;
        private Random _random;
        private Stack<int> _savedTurns;
        private int _currentNumber;
        private int _goalNumber;
        private int _currentTurn = 0;

        public int CurrentNumber => _currentNumber;
        public int GoalNumber => _goalNumber;
        public int CurrentTurn => _currentTurn;

        public Doubler()
        {
            _random = new Random();
            _savedTurns = new Stack<int>();
        }

        public void StartNewGame()
        {
            _currentTurn = 0;
            _savedTurns.Clear();
            _currentNumber = _random.Next(START_MAX);
            _goalNumber = _random.Next(START_MAX, GOAL_MAX);
        }

        public void AddOneToNumber()
        {
            SaveTurn();
            _currentNumber++;
            _currentTurn++;
        } 
        
        public void MultiplyByTwoNumber()
        {
            SaveTurn();
            _currentNumber *= 2;
            _currentTurn++;
        }

        public bool IsGameOver()
        {
            return _currentNumber == _goalNumber;
        }

        public void UndoTurn()
        {
            if(_savedTurns.Count == 0)
                return;
            
            _currentNumber = _savedTurns.Pop();
            _currentTurn--;
        }

        private void SaveTurn()
        {
            _savedTurns.Push(_currentNumber);
        }
    }
}
