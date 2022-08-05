using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_05
{
    internal class Program
    {
        /* Губин Андрей Игоревич
         * 5.   а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
                б) *Сделать задание, только вывод организовать в центре экрана.
                в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int
                     x,int y). */

        static void Main(string[] args)
        {
            int posX = 30;
            int posY = 20;
            string name = "Андрей";
            string familyName = "Губин";
            string city = "Севастополь";
            string messageToPrint = $"Меня зовут {familyName} {name} и я живу в городе {city}.";

            Console.WriteLine(messageToPrint);

            Console.SetCursorPosition((Console.WindowWidth - messageToPrint.Length) / 2, Console.WindowHeight / 2 - 1);
            Console.WriteLine(messageToPrint);

            PrintGreetings(messageToPrint, posX, posY, ConsoleColor.Magenta);
            Console.ReadLine();
        }

        static void PrintGreetings(string message, int messagePosX, int messagePosY,
            ConsoleColor textColor = ConsoleColor.White)
        {
            Console.SetCursorPosition(messagePosX, messagePosY);
            Console.ForegroundColor = textColor;
            Console.WriteLine(message);
        }
    }
}
