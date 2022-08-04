using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_02
{
    internal class Program
    {
        /* 
           Губин Андрей Игоревич
            2. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле
           I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах. 
        */

        static void Main(string[] args)
        {
            Console.WriteLine("Для рассчёта индекса массы тела (ИМТ) введите ваш");
            Console.Write("Рост в метрах: ");
            string inputHeight = Console.ReadLine();
            Console.Write("Массу тела в килограммах: ");
            string inputWeight = Console.ReadLine();
            if (double.TryParse(inputWeight, out double weight) &&
                double.TryParse(inputHeight, out double height))
            {
                double bmi = weight / (height * height);
                Console.WriteLine($"Ваш ИМТ составляет {bmi:F2}.");
            }
            else
            {
                Console.WriteLine("Неправильно введен рост или вес!");
            }
            Console.ReadLine();
        }
    }
}
