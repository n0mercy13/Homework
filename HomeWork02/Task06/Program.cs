using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task06
{
    internal class Program
    {
        /* 6. *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000
            000. «Хорошим» называется число, которое делится на сумму своих цифр. Реализовать
            подсчёт времени выполнения программы, используя структуру DateTime. */

        static DateTime startTime;

        static void Main(string[] args)
        {
            int range = 1_000_000_000;
            startTime = DateTime.Now;

            Console.WriteLine($"In range from 1 to {range} we have {CountGoodNumbers(range)} 'good' numbers");
            CheckTimer(startTime);
            Console.ReadLine();
        }

        static int CountGoodNumbers(int range)
        {
            int count = 0;
            for (int i = 1; i <= range; i++)
            {
                if(IsNumberGood(i))
                    count++;
            }
            return count;
        }        

        // Using Loop - fastest (33.33sec)

        private static bool IsNumberGood(int number)
        {
            var originalNumber = number;
            var sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return originalNumber % sum == 0;
        }

        // Using Recursive func - slow (125.95sec)

        //private static bool IsNumberGood(int number)
        //{
        //    var sum = GetSumOfDigits_Recursive(number);

        //    return number % sum == 0;
        //}

        // Using string & Linq - slowest (195.94sec)

        //private static bool IsNumberGood(int number)
        //{
        //    var sum = number
        //        .ToString()
        //        .ToCharArray()
        //        .Select(digit => (int)char.GetNumericValue(digit))
        //        .Sum();
        //    return number % sum == 0;
        //}

        private static int GetSumOfDigits_Recursive(int number)
        {
            if (number == 0)
                return 0;

            return number % 10 + GetSumOfDigits_Recursive(number / 10);
        }

        private static void CheckTimer(DateTime startTime)
        {
            Console.WriteLine($"Operation duration: {(DateTime.Now - startTime).TotalSeconds:F2} sec");
        }
    }
}
