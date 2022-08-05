using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    internal class Program
    {
        /* Губин Андрей Игоревич
         * 4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На
            выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password:
            GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь
            вводит логин и пароль, программа пропускает его дальше или не пропускает. С помощью
            цикла do while ограничить ввод пароля тремя попытками. */
        static void Main(string[] args)
        {            
            int attemptsCounter = 3;

            do
            {
                Console.WriteLine($"\nYou have {attemptsCounter} attempt(s) to log in.");
                attemptsCounter--;

                Console.Write("Login: ");
                string loginInput = Console.ReadLine();
                Console.Write("Password: ");
                string passwordInput = Console.ReadLine();

                if(IsAccessGranted(loginInput, passwordInput))
                {                    
                    Console.WriteLine($"Access granted.\nWelcome, {loginInput}.");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    Console.WriteLine($"Wrong login or/and password.");                    
                }
            }
            while(attemptsCounter > 0);

            Console.WriteLine("Account was blocked. Have a nice day.");
            Console.ReadLine();
        }

        static bool IsAccessGranted(string login, string password)
        {
            const string CORRECT_LOGIN = "root";
            const string CORRECT_PASSWORD = "GeekBrains";

            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) return false;
            return (login == CORRECT_LOGIN && password == CORRECT_PASSWORD) ? true : false;
        }

    }
}
