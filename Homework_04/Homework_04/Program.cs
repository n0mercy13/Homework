using System;
using System.Collections.Generic;
using Homework.Utility;

namespace Homework_04
{
    
    public class Program
    {
        static void Main(string[] args)
        {
            List<Action> tasks = new List<Action>()
            {
                Lesson04_Task01.RunTask01,
                Lesson04_Task02.RunTask02,
            };

            new HomeworkAssist(4, tasks);
        }
    }
}
