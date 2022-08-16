using System;
using System.Collections.Generic;
using System.Text;
using Homework.Utility;

namespace Homework_05
{
    public class Lesson05_Task03
    {
        private static Random _random = new Random();
        private static Dictionary<char, int> _dict = new Dictionary<char, int>();
        private static List<string> _wordsPool = new List<string>()
        {
            "Apollo", "Hestia", "Hades", "Aphrodite", "Artemis", "Dionysos",
            "Zeus", "Ares", "Athene", "Hermes", "Poseidon", "Demeter",
        };

        public static void RunTask03()
        {
            string randomWord = GetRandomWord();
            HomeworkAssist.ParseInput($"Please input anagram of word '{randomWord}': ", out string anagram);

            if (randomWord.ToLower() == anagram.ToLower())
            {
                Console.WriteLine($"Hmm, '{anagram}' is the same as '{randomWord}'. You are no fun at all((");
                return;
            }
              
            if (IsWordsAnagrams(randomWord, anagram))
                Console.WriteLine($"Awesome, '{anagram}' is anagram of the '{randomWord}'");
            else
                Console.WriteLine($"Oh no, looks like '{anagram}' is not anagram of the '{randomWord}'");
        }

        #region Task03 methods

        private static string GetRandomWord()
        {
            int randomIndex = _random.Next(_wordsPool.Count);
            return _wordsPool[randomIndex];
        }

        private static bool IsWordsAnagrams(string word1, string word2)
        {
            _dict.Clear();

            foreach (char c in word1.ToLower().ToCharArray())
            {
                if (_dict.ContainsKey(c))
                    _dict[c]++;
                else
                    _dict.Add(c, 1);
            }                

            foreach (char c in word2.ToLower().ToCharArray())
            {
                if (_dict.ContainsKey(c))
                    _dict[c]--;
                else
                    return false;
            }

            foreach (int item in _dict.Values)
            {
                if(item != 0)
                    return false;
            }
              
            return true;
        }

        #endregion
    }
}
