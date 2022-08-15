using System;
using System.Collections.Generic;
using Homework.Utility;

namespace Homework_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Action> tasks = new List<Action>()
            {
                Lesson05_Task01.RunTask01,
                Lesson05_Task02.RunTask02,
                Lesson05_Task03.RunTask03,
                Lesson05_Task04.RunTask04,
            };

            new HomeworkAssist(5, tasks);
        }
    }
}
