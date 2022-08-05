using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework.Utility;

namespace Homework_03
{
    public delegate void RunTask();

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Action> tasks = new List<Action>()
            {
                Task01.RunTask01,
                Task02.RunTask02
            };

            new HomeworkAssist(3, tasks);            
        }
    }
}
