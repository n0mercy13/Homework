using System;
using System.Collections.Generic;

namespace Homework_04
{
    using Homework.Utility;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Action> tasks = new List<Action>()
            {
                new Lesson04_Task01().RunTask01,
                new Lesson04_Task02().RunTask02,
            };

            new HomeworkAssist(4, tasks);
        }
    }
}
