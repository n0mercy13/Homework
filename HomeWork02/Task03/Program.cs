using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task03
{
    internal class Program
    {
        /* Губин Андрей Игоревич
         * 3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных
            положительных чисел. */

        

        static void Main(string[] args)
        {           
            GetSumFromUserInput_Loop();
            GetSumFromUserInput_Recursion();
            Console.ReadLine();
        }

        private static void GetSumFromUserInput_Loop()
        {   
            int sum = 0;
            string input = String.Empty;
            do
            {
                Console.Write("Please enter any integer or '0' to show result: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    sum += ((number > 0) && (number % 2 != 0)) ? number : 0;
                }
            }
            while (input != "0");

            Console.WriteLine($"The sum of all positive and odd numbers is {sum}.");
        }

        private static void GetSumFromUserInput_Recursion(int sum = 0)
        {
            Console.Write("Please enter any integer or '0' to show result: ");
            if(int.TryParse(Console.ReadLine(), out int number))
            {
                if(number == 0)
                {
                    Console.WriteLine($"The sum of all positive and odd numbers is {sum}.");
                    return;
                }

                sum += ((number > 0) && (number % 2 != 0)) ? number : 0;
                GetSumFromUserInput_Recursion(sum);
            }
            else
            {
                GetSumFromUserInput_Recursion(sum);
            }
        }
    }
}
