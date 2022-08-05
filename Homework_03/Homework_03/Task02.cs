using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_03
{
    using Homework.Utility;

    public class Task02
    {
        public static void RunTask02()
        {
            int sum = 0;
            int num;

            Console.WriteLine("Please type any integer and program will\n" +
                "calculate sum of all positive odd numbers.\n" +
                "Press '0' to check result.");
            Console.WriteLine(HomeworkAssist.SEPARATION);

            while (true)
            {
                num = HomeworkAssist.ParseInputInt("Please input number: ");

                if(num == 0)
                    break;
                else if(num % 2 != 0 && num > 0)
                    sum += num;
            }
            Console.WriteLine($"Sum of all positive odd numbers is {sum}");
            Console.WriteLine("Press any key to quit...");
            Console.ReadLine();

        }
    }
}
