using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Utility
{
    public class HomeworkAssist
    {
        private const string SEPARATION = "-----------------------------------";
        private const string MY_NAME = "Gubin Andrey";
        private int _lessonNumber;
        private int _tasksCount => _tasks.Count;
        private List<Action> _tasks;
        private bool IsRunning = true;
        

        /// <summary>
        /// Generates menu for the lesson homework
        /// </summary>
        /// <param name="lessonNumber">Current lesson number</param>
        /// <param name="tasks">List of tasks for the homework</param>
        public HomeworkAssist(int lessonNumber, List<Action> tasks)
        {
            _lessonNumber = lessonNumber;
            _tasks = new List<Action>(tasks);
            GetMenu();
        }        

        /// <summary>
        /// Print out in console student info
        /// </summary>
        private void PrintInfo()
        {
            Console.WriteLine(SEPARATION);
            Console.WriteLine($"Student: {MY_NAME}");
            Console.WriteLine($"Lesson #{_lessonNumber:D2} Tasks from 1 to {_tasksCount}");
            Console.WriteLine(SEPARATION);
        }

        /// <summary>
        /// Generates menu for homework
        /// </summary>
        private void GetMenu()
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

        /// <summary>
        /// Print out in console task number
        /// </summary>
        /// <param name="taskNumber">Task number</param>
        public static void PrintTaskInfo(string taskNumber)
        {
            PrintSeparation();
            Console.WriteLine($"Task #{taskNumber} is running{Environment.NewLine}");
            PrintSeparation();
        }

        /// <summary>
        /// Print out in console predefined separation line
        /// </summary>
        public static void PrintSeparation()
        {
            Console.WriteLine(SEPARATION);
        }

        /// <summary>
        /// Parse input of any int value
        /// </summary>
        /// <param name="message">Print out message,
        /// explainning type of required inputs</param>        
        public static void ParseInput(string message, out int result)
        {
            result = 0;
            do
            {
                Console.Write(message);
            }
            while(!int.TryParse(Console.ReadLine(), out result));            
        }

        /// <summary>
        /// Parse input of any double value
        /// </summary>
        /// <param name="message">Print out message,
        /// explainning type of required inputs</param>        
        public static void ParseInput(string message, out double result)
        {
            result = 0;
            do
            {
                Console.Write(message);
            }
            while (!double.TryParse(Console.ReadLine(), out result));            
        }

        /// <summary>
        /// Handles string input
        /// </summary>
        /// <param name="message">Print out message,
        /// explainning type of required inputs</param> 
        public static void ParseInput(string message, out string result)
        {
            Console.Write(message);
            result = Console.ReadLine();
        }
    }
}
