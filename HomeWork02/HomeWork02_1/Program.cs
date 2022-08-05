using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    /* Губин Андрей Игоревич
    1. Написать метод, возвращающий минимальное из трёх чисел. */

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please, enter 1st number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Please, enter 2nd number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write("Please, enter 3rd number: ");
            int num3 = int.Parse(Console.ReadLine());

            int min = MinNumber(num1, num2, num3);
            Console.WriteLine($"Minimum number is {min}");
            Console.ReadLine();
        }

        static int MinNumber(int num1, int num2, int num3)
        {
            int min = num1 < num2 ? num1 : num2;
            min = min < num3 ? min : num3;
            return min;            
        }
    }
}
