using System;
using System.Collections.Generic;
using Homework.Utility;

namespace Homework_05
{
    internal class Program
    {
        private static List<Action> _tasks = new List<Action>()
            {
                Lesson05_Task01.RunTask01,
                Lesson05_Task02.RunTask02,
                Lesson05_Task03.RunTask03,
                Lesson05_Task04.RunTask04,
            };

        static void Main(string[] args)
        {
            new HomeworkAssist(5, _tasks);
        }
    }
}
