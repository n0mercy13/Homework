using System;
using System.Collections.Generic;
using System.Text;
using Homework.Utility;

namespace Homework_05
{
    public class Lesson05_Task02
    {
        public static void RunTask02()
        {
            RunTask02a();
            RunTask02b();
            RunTask02c();
            RunTask02d();
            RunTask02f();
        }

        #region Task02 methods

        private static void RunTask02a()
        {
            HomeworkAssist.ParseInput("\nPlease input some text: ", out string message);
            HomeworkAssist.ParseInput("Please chose maximum lenght of words: ", out int wordLength);
            Console.WriteLine($"Print out only words with no more then {wordLength} characters:");
            Console.WriteLine(Message.OutputSmallWords(message,wordLength));
        }

        private static void RunTask02b()
        {
            HomeworkAssist.ParseInput("\nPlease input some text: ", out string message);
            HomeworkAssist.ParseInput("Please chose some character: ", out string endChar);
            Console.WriteLine($"Print out only words which last letter is not '{endChar}'");
            Console.WriteLine(Message.DeleteWordsEndingOnChar(message, endChar[0]));
        }

        private static void RunTask02c()
        {
            HomeworkAssist.ParseInput("\nPlease input some text: ", out string message);            
            Console.WriteLine($"The longest word of this text is '{Message.FindTheLongestWord(message)}'");            
        }

        private static void RunTask02d()
        {
            string message = string.Empty;
            Message.ClearMessage();

            HomeworkAssist.ParseInput("\nPlease input some text: ", out message);            
            Message.AddToMessage(Message.FindTheLongestWord(message));
            HomeworkAssist.ParseInput("Please input some more text: ", out message);            
            Message.AddToMessage(Message.FindTheLongestWord(message));
            HomeworkAssist.ParseInput("And finally input a little bit more text: ", out message);
            Message.AddToMessage(Message.FindTheLongestWord(message));

            Console.WriteLine("The longest words of your messages are: ");
            Message.PrintMessage();
        }

        private static void RunTask02f()
        {
            List<string> wordsToCheck = Message.GetRandomWords();
            Message.ClearMessage();
            Message.AddToMessage(wordsToCheck);
            Console.WriteLine("\nYour input will be checked if it contains the following words:");
            Message.PrintMessage();
            HomeworkAssist.ParseInput("Please input some text: ", out string message);
            Console.WriteLine($"The following matches were found: ");
            Message.PrintOutHowManyGivenWordsInMessage(wordsToCheck, message);
        }        

        #endregion
    }

    #region class Message

    public static class Message
    {
        private static Random _random = new Random();
        private static StringBuilder _message = new StringBuilder();
        private static Dictionary<string, int> _dictonary = new Dictionary<string, int>();
        private static readonly string[] _separators = new string[]
        {
            " ", "/", ".", ":", ";", ",",
        };
        private static List<string> _poolOfwords = new List<string>()
        {
            "good", "excellent", "superb", "fantastic", "awesome",
            "modest", "average", "so-so",
            "bad", "worst", "awful", "horrible",
        };


        /// <summary>
        /// Returns string with maximum lenght of words
        /// </summary>
        /// <param name="message">Text to process</param>
        /// <param name="wordLength">Maximum lenght of words</param>
        /// <returns>Returns string with maximum lenght of words</returns>
        public static string OutputSmallWords(string message, int wordLength)
        {
            string[] words = message.Split(_separators,StringSplitOptions.RemoveEmptyEntries);
            List<string> outputWords = new List<string>();

            foreach(string word in words)
                if(word.Length <= wordLength)
                    outputWords.Add(word);

            return string.Join(" ", outputWords);
        }

        /// <summary>
        /// Removes words from string ending on given char
        /// </summary>
        /// <param name="message">String to process</param>
        /// <param name="endChar">Char to check</param>
        /// <returns>String without words ending on given char</returns>
        public static string DeleteWordsEndingOnChar(string message, char endChar)
        {
            string[] words = message.Split(_separators,StringSplitOptions.RemoveEmptyEntries);
            List<string> outputWords = new List<string>();

            foreach (string word in words)
                if (word[word.Length - 1] != endChar)
                    outputWords.Add(word);

            return string.Join(" ", outputWords);
        }

        /// <summary>
        /// Finds the longest word in string
        /// </summary>
        /// <param name="message">String to process</param>
        /// <returns>First longest word in string</returns>
        public static string FindTheLongestWord(string message)
        {
            string[] words = message.Split(_separators,StringSplitOptions.RemoveEmptyEntries);
            string theLongestWord = words[0];            

            for (int i = 1; i < words.Length; i++)            
                if(theLongestWord.Length < words[i].Length)                
                    theLongestWord = words[i];
                    
            return theLongestWord;            
        }

        /// <summary>
        /// Add text to message
        /// </summary>
        /// <param name="text">Text to add</param>
        public static void AddToMessage(string text) => _message.Append($"{text} ");  
        
        /// <summary>
        /// Add list of words to message
        /// </summary>
        /// <param name="words">List of words</param>
        public static void AddToMessage(List<string> words)
        {
            foreach (string word in words)
                _message.Append($"{word} ");
        }

        /// <summary>
        /// Clears message
        /// </summary>        
        public static void ClearMessage() => _message.Clear();        

        /// <summary>
        /// Print out message in console
        /// </summary>
        public static void PrintMessage() => Console.WriteLine(_message);   
        
        /// <summary>
        /// Print outs how many words from the list are found in the message
        /// </summary>
        /// <param name="wordsToCheck">List with words to compare</param>
        /// <param name="message">Message to check</param>
        public static void PrintOutHowManyGivenWordsInMessage(List<string> wordsToCheck, string message)
        {            
            string[] words = message.Split(_separators,StringSplitOptions.RemoveEmptyEntries);
            _dictonary.Clear();

            foreach (string word in wordsToCheck)
                _dictonary.Add(word, 0);

            foreach (string word in words)            
                if (_dictonary.ContainsKey(word.ToLower()))
                    _dictonary[word]++;

            if (IsAnyMatchFound())
            {
                foreach (var item in _dictonary)
                    if (item.Value >  0)
                        Console.WriteLine($"You can find word '{item.Key}' " +
                            $"in message '{item.Value}' time{(item.Value <= 1 ? "" : "s")}");
            }
            else
            {
                Console.WriteLine("No matches found");
            }
        }

        private static bool IsAnyMatchFound()
        {
            bool isMatchFound = false;

            foreach (int value in _dictonary.Values)
            {
                if(value > 0)
                    isMatchFound = true;
            }

            return isMatchFound;
        }

        /// <summary>
        /// Generates random list of words from predefined pool
        /// </summary>
        /// <returns>List of random words</returns>
        public static List<string> GetRandomWords()
        {
            int randomIndex;
            int numberOfWords = _random.Next(3, 6);
            List<string> randomWords = new List<string>();

            for (int i = 0; i < numberOfWords; i++)
            {
                randomIndex = _random.Next(_poolOfwords.Count);
                if (!randomWords.Contains(_poolOfwords[randomIndex]))
                    randomWords.Add(_poolOfwords[randomIndex]);
            }

            return randomWords;
        }
    }

    #endregion
}
