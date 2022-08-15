using Homework.Utility;
using System;
using System.Collections.Generic;
using System.IO;

namespace Homework_04
{
    public class Lesson04_Task02
    {
        private const int ATTEMPTS = 3;
        private static PasswordManager _passwordManager = new PasswordManager();

        public static void RunTask02()
        {
            InitializeUserData();
            Login();
        }

        #region Task02 methods

        private static void InitializeUserData()
        {
            _passwordManager.AddUser("root", "GeekBrain");
            _passwordManager.AddUser("user1", "abcdfg");
            _passwordManager.AddUser("user2", "12345");
        }

        private static void Login()
        {
            int attemptsCounter = ATTEMPTS;

            do
            {
                Console.WriteLine($"\nYou have {attemptsCounter} attempt(s) to log in.");
                attemptsCounter--;

                HomeworkAssist.ParseInput("Login: ", out string loginInput);
                HomeworkAssist.ParseInput("Password: ", out string passwordInput);

                if (_passwordManager.IsAccountValid(loginInput, passwordInput))
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
            while (attemptsCounter > 0);

            Console.WriteLine("Access was blocked. Have a nice day.");
            Console.ReadLine();
        }
    }

    #endregion

    #region class PasswordManager

    public class PasswordManager
    {
        private List<Account> _accounts = new List<Account>();
        private string fileName = "UsersData.txt";
        private string _path;

        public void AddUser(string login, string password)
        {
            Account newUser = new Account(login, password);
            _accounts.Add(newUser);
            SaveUsersData(login, password);
        }

        public PasswordManager()
        {
            _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);

            if (!File.Exists(_path))
            {
                var fs = new FileStream(_path, FileMode.Create);
                fs.Close();
            }

            if (LoadUsersData() != null)
                _accounts = new List<Account>(LoadUsersData());
        }

        public bool IsAccountValid(string login, string password)
        {
            Account accountToCheck = new Account(login, password);

            foreach (var account in _accounts)
            {
                if (account.Equals(accountToCheck))
                    return true;
            }

            return false;
        }

        private bool IsUserSaved(string login, string password)
        {
            if (LoadUsersData() == null) return false;

            Account newAccount = new Account(login, password);
            List<Account> accounts = new List<Account>(LoadUsersData());

            foreach (var account in accounts)
            {
                if (account.Equals(newAccount))
                    return true;
            }

            return false;
        }

        private List<Account> LoadUsersData()
        {
            if (new FileInfo(_path).Length == 0) return null;

            var loadedUsers = new List<Account>();

            using (var reader = new StreamReader(_path))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split("/");
                    string login = line[0];
                    string password = line[1];
                    Account newUser = new Account(login, password);
                    loadedUsers.Add(newUser);
                }
            }

            return loadedUsers;
        }

        private void SaveUsersData(string login, string password)
        {
            if (!IsUserSaved(login, password))
            {
                string userData = $"{login}/{password}";

                using (var writer = new StreamWriter(_path, true))
                    writer.WriteLine(userData);
            }
        }

        #endregion

        #region struct Account

        public struct Account
        {
            private readonly string _login;
            private readonly string _password;

            public Account(string login, string password)
            {
                _login = login;
                _password = password;
            }

            public bool Equals(Account account) => this._login == account._login
                                                        && this._password == account._password;

            public override string ToString() => $"User: {_login.Substring(0, 2)}*****";
        }

        #endregion
    }


}
