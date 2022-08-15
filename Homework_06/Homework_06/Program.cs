using System;
using System.Collections.Generic;
using Homework.Utility;


namespace Homework_06
{
    internal class Program
    {
        private static List<Action> _tasks = new List<Action>()
        {
            Lesson06_Task01.RunTask01,
        };

        static void Main(string[] args)
        {
            new HomeworkAssist(6, _tasks);
        }
    }
}
