using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lesson07_Task02
{
    internal static class Program
    {
        private static int _turns = 0;       

        public static FormMain FormMain { get; private set; }
        public static FormInput FormInput { get; private set; }
        public static GuessNumber GuessNumber { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormMain = new FormMain();
            FormInput = new FormInput();
            GuessNumber = new GuessNumber();
            Application.Run(FormMain);
        }

        public static void MakeTurn(int number)
        {
            _turns++;

            UpdateUI(number);

            if (GuessNumber.IsGameOver(number))
                GameFinished();            
        }

        private static void GameFinished()
        {
            FormInput.Close();
            FormInput.ResetForm();
            FormMain.ResetFrom();
        }

        public static void RestartGame()
        {
            _turns = 0;
            FormInput.ShowDialog();
        }

        public static void UpdateUI(int number)
        {
            FormMain.UpdateInfoLabel(number);
            FormMain.UpdateNumberLabel(number);
            FormMain.UpdateTurnLabel(_turns);
        }
    }
}
