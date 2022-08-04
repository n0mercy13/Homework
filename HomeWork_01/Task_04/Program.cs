using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_04
{
    internal class Program
    {
        /*
         * Губин Андрей Игоревич
         * 4. Написать программу обмена значениями двух переменных:
            а) с использованием третьей переменной;
            б) *без использования третьей переменной.
         */
        static void Main(string[] args)
        {
            int x = 1;
            int y = 9;
            int tempInt;

            Console.WriteLine($"x = {x} / y = {y} (Initial)");

            tempInt = x;
            x = y;
            y = tempInt;

            Console.WriteLine($"x = {x} / y = {y} (After swaping)");

            x = x + y;
            y = x - y;
            x = x - y;

            Console.WriteLine($"x = {x} / y = {y} (Swaping back)");
            Console.ReadLine();
        }
    }
}
