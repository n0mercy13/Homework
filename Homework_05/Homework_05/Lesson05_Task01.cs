using Homework.Utility;
using System;

namespace Homework_05
{
    public class Lesson05_Task01
    {
        private static string _login = string.Empty;

        public static void RunTask01()
        {
            do
            {
                HomeworkAssist.ParseInput("Please type new login (use only letters and digits): ", out _login);
            }
            while (!IsLoginCorrect(_login));

            Console.WriteLine($"You new login is '{_login}'");
        }

        #region Task01 methods

        private static bool IsLoginCorrect(string login) => IsLoginLenthCorrect(login)
                                                    && IsFirstCharNotDigit(login)
                                                    && IsAllCharsLettersOrDigits(login);

        private static bool IsAllCharsLettersOrDigits(string login)
        {
            bool isAllCharsLettersOrDigits = true;

            foreach (var c in login)
            {
                if (!char.IsLetterOrDigit(c))
                    isAllCharsLettersOrDigits = false;
            }

            if (!isAllCharsLettersOrDigits)
                Console.WriteLine("Login cannot contain any special characters");

            return isAllCharsLettersOrDigits;
        }

        private static bool IsFirstCharNotDigit(string login)
        {
            if (char.IsDigit(login[0]))
            {
                Console.WriteLine("Login cannot start with digit");
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool IsLoginLenthCorrect(string login)
        {
            if (login.Length < 2 || login.Length > 10)
            {
                Console.WriteLine("Login should be from 2 to 10 characters");
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
