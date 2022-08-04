using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    internal class Program
    {
        /* Губин Андрей Игоревич
         * 2. Написать метод подсчета количества цифр числа. */

        static void Main(string[] args)
        {
            Console.Write("Please enter number: ");
            int number = int.Parse(Console.ReadLine());
            
            Console.WriteLine($"There are {GetNumberOfDigits_String(number)} digit(s) in your number.");
            Console.WriteLine($"There are {GetNumberOfDigits_Loop(number)} digit(s) in your number.");
            Console.WriteLine($"There are {GetNumberOfDigits_Recursive(number)} digit(s) in your number.");
            Console.ReadLine();
        }

        static int GetNumberOfDigits_String(int number)
        {
            int numberLength = number.ToString().Length;
            
            return (number >= 0) ? numberLength : numberLength - 1;
        }

        static int GetNumberOfDigits_Loop(int number)
        {
            int count = 0;
            do
            {
                number /= 10;
                count++;
            } 
            while (number != 0);

            return count;
        }

        static int GetNumberOfDigits_Recursive(int number, int digits = 0)
        {
            if (number == 0 && digits == 0)
                return 1;
            if(number == 0)
                return digits;
            return GetNumberOfDigits_Recursive(number / 10, ++digits);
        }

    }
}
