using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    internal class Program
    {
        /*
         * Губин Андрей Игоревич
         * а) Написать программу, которая подсчитывает расстояние между точками с координатами x1,
            y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат,
            используя спецификатор формата .2f (с двумя знаками после запятой);
            б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде
            метода.
         */
        static void Main(string[] args)
        {
            double x1 = DeclareCoordinate("Введите значение координаты х первой точки: ");
            double y1 = DeclareCoordinate("Введите значение координаты y первой точки: ");
            double x2 = DeclareCoordinate("Введите значение координаты х второй точки: ");
            double y2 = DeclareCoordinate("Введите значение координаты y второй точки: ");

            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine($"Расстояние между точками составляет {distance:F2}.");
            Console.WriteLine($"Расстояние между точками составляет {DistanceBetweenTwoPoints(x1, y1, x2, y2):F2}.");
            Console.ReadLine();
        }

        static double DeclareCoordinate(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (double.TryParse(input, out double coordinate))
            {
                return coordinate;
            }
            else
            {
                Console.WriteLine("Неверное значение координаты, установленно значение по умолчанию (0,00)");
                return 0;
            }
        }

        static double DistanceBetweenTwoPoints(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
    }
}
