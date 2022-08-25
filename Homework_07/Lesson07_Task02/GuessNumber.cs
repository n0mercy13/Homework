using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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

        public bool IsGameOver(int number) => _numberToGuess == number;        

        private string GetRandomInterjection() => _interjections[_random.Next(_interjections.Length)];

        public string PrintComments(int number)
        {
            if (number < _numberToGuess)
            {
                return $"{GetRandomInterjection()}, the number that I think of is MORE";               
            }
            else if (number > _numberToGuess)
            {
                return $"{GetRandomInterjection()}, the number that I think of is LESS";                
            }
            else
            {
                return "Amazing, that's the right number!";                
            }
        }
    }
}
