using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Utility
{
    public class HomeworkAssist
    {
        private const string MY_NAME = "Gubin Andrey";
        private int _lessonNumber;
        private int _tasksCount => _tasks.Count;
        private List<Action> _tasks;
        private bool IsRunning = true;
        
        public const string SEPARATION = "-----------------------------------";

       
        public HomeworkAssist(int lessonNumber, List<Action> tasks)
        {
            _lessonNumber = lessonNumber;
            _tasks = new List<Action>(tasks);
            GetMenu();
        }

        public HomeworkAssist() { }

        private void PrintInfo()
        {
            Console.WriteLine(SEPARATION);
            Console.WriteLine($"Student: {MY_NAME}");
            Console.WriteLine($"Lesson #{_lessonNumber:D2} Tasks from 1 to {_tasksCount}");
            Console.WriteLine(SEPARATION);
        }

        public void GetMenu()
        {
                PrintInfo();
            do
            {                
                Console.WriteLine($"Tasks from 1 to {_tasksCount} available");
                Console.Write("Type task 'number' to run or '0' to quit: ");
                if(int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int taskIndex))
                {                    
                    if(taskIndex == 0)
                    {
                        IsRunning = false;
                        break;
                    }
                    else if(taskIndex > 0 && taskIndex <= _tasksCount)
                    {                        
                        Console.WriteLine($"\nTask #{taskIndex} is running\n");
                        _tasks[taskIndex - 1]?.Invoke();
                    }
                    else
                    {
                        Console.WriteLine("\nWrong task number. Please try again.");
                    }
                }
            }
            while(IsRunning);
            Console.WriteLine("\nPress any key to quit...");
            Console.ReadKey();
        }

        public static int ParseInputInt(string message)
        {
            int result = 0;
            do
            {
                Console.Write(message);
            }
            while(!int.TryParse(Console.ReadLine(), out result));
            return result;
        }

        public static double ParseInputDouble(string message)
        {
            double result = 0;
            do
            {
                Console.Write(message);
            }
            while (!double.TryParse(Console.ReadLine(), out result));
            return result;
        }
    }
}
