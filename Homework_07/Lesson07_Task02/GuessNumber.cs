using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson07_Task02
{
    public class GuessNumber
    {        
        private readonly string[] _interjections = 
        {
            "Oh no" , "Boy" , "My gosh", "Nope",
            "Meh", "Eh", "Er", "Oww!", "Humph", "Nuh-uh", "Umm",
        };
        private readonly Random _random;        
        private int _numberToGuess;

        public const int MIN = 1;
        public const int MAX = 100;

        public GuessNumber()
        {
            _random = new Random();
            SetNewRandomNumber();
        }        

        public void SetNewRandomNumber()
        {
            _numberToGuess = _random.Next(MIN, MAX + 1);
        }

        public bool CheckNumberAndGetComments(int numberToCheck, out string comments)
        {
            if(numberToCheck < _numberToGuess)
            {
                comments = $"{GetRandomInterjection()}, the number that I think of is MORE";
                return false;
            }
            else if(numberToCheck > _numberToGuess)
            {
                comments = $"{GetRandomInterjection()}, the number that I think of is LESS";
                return false;
            }
            else
            {
                comments = "Amazing, that's the right number!";
                return true;
            }
        }

        private string GetRandomInterjection() => _interjections[_random.Next(_interjections.Length)];
    }
}
