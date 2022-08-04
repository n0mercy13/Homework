using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    internal class Program
    {
        /*
            Губин Андрей Игоревич
             1. Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст,
            рост, вес). В результате вся информация выводится в одну строчку:
            а) используя склеивание;
            б) используя форматированный вывод;
            в) используя вывод со знаком $.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Пожалуйста ответьте на вопросы нашей анкеты");
            Console.Write("Ваше имя: ");
            string name = Console.ReadLine();
            Console.Write("Ваша фамилия: ");
            string familyName = Console.ReadLine();
            Console.Write("Ваш возраст (полных лет): ");
            string age = Console.ReadLine();
            Console.Write("Ваш рост (см): ");
            string height = Console.ReadLine();
            Console.Write("Ваш вес (кг): ");
            string weight = Console.ReadLine();

            Console.WriteLine(name + " " + familyName + " " + age + " лет " + height + " см " + weight + " кг");
            Console.WriteLine("{0} {1} {2} лет {3} см {4} кг", name, familyName, age, height, weight);
            Console.WriteLine($"{name} {familyName} {age} лет {height} см {weight} кг");
            Console.ReadLine();
        }
    }
}
