using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson08_Task02
{
    public partial class Form1 : Form
    {
        private GameState _game = new GameState();
        private readonly string _instructions =
            $"First: Open a file with a set of questions (File -> Open);{Environment.NewLine}" +
            $"Second: Start a new game (Game -> New Game);{Environment.NewLine}" +
            $"Third: Try to guess the right answer and press coresponding button;{Environment.NewLine}" +
            $"And last but not the least: Enjoy the game ;)";
        #region Questions
        private List<Question> _questions = new List<Question>()
        {
            new Question("If you break an egg, can you fix it?", false),
            new Question("If you were a fish, could you jump?", false),
            new Question("If you want to watch a movie, would you go to a bank?", true),
            new Question("If something is tasty, is it bad?", true),
            new Question("If there is snow on the ground, is it summer?", false),
            new Question("Is your arm bigger than your thigh?", false),
            new Question("Is twenty more than fifty?", false),
            new Question("Is half an apple less than one apple?", false),
            new Question("Is a pair of shoes more than one shoe?", true),
            new Question("Is a pair of socks less than three pairs?", false),
            new Question("Is a day longer than a week?", false),
            new Question("Is a year longer than six months?", true),
            new Question("Is a mile longer than a football field?", true),
            new Question("If you were a horse, could you gallup?", true),
            new Question("If you were a cat, would you have three legs?", false),
            new Question("If you were a bee, could you sing?", false),
            new Question("If you were a shark, would you eat fish?", true),
            new Question("If you break an egg, can you fix it?", false),
            new Question("If you rip your shirt, would you staple it back together?", false),
            new Question("If it is June, is it hot in the North Pole?", false),
            new Question("If you have a bracelet, do you own jewelry?", false),
            new Question("If you were a bird, would you have fins?", false),
            new Question("If you have boiling water, is it hot?", true),
            new Question("If something is light, would it sink?", true),
            new Question("If something smells, does it stink?", false),
            new Question("If you have a pen and paper, can you write your name?", false),
            new Question("If you were an ant, would you live in dirt?", false),           
        };
        #endregion


        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            ShowGameInstractions();            
            InitialSettingsSave();
            InitialSettingsLoad();
        }

        private void InitialSettingsSave()
        {
            saveFileDialog1.InitialDirectory =
                            AppDomain.CurrentDomain.BaseDirectory;
            saveFileDialog1.FileName = string.Empty;
            saveFileDialog1.DefaultExt = ".json";
            saveFileDialog1.Filter = "Json files (.json)|*.json";
        }

        private void InitialSettingsLoad()
        {
            openFileDialog1.InitialDirectory =
                            AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.DefaultExt = ".json";
            openFileDialog1.Filter = "Json files (.json)|*.json";
        }

        private void ShowGameInstractions()
        {
            textBoxQuestion.Text = _instructions;
        }

        private void UpdateForm()
        {
            textBoxQuestion.Text = _game.GetQuestionText();
            labelInfo.Text = _game.GetStatus();
        }

        private void OnButtonPressed(bool answer)
        {
            _game.CheckAnswer(answer);
            _game.GetNextQuestion();
            UpdateForm();

            if (_game.IsGameOver)
            {
                GameOver();
            }
        }

        private void GameOver()
        {
            SetButtons(false);
        }

        public void SetButtons(bool state)
        {
            buttonBelive.Enabled = state;
            buttonNotBelive.Enabled = state;
        }        

        #region Events

        private void buttonBelive_Click(object sender, EventArgs e)
        {
            OnButtonPressed(true);
        }

        private void buttonNotBelive_Click_1(object sender, EventArgs e)
        {
            OnButtonPressed(false);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                _game.LoadQuestionsBase(file);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string save = saveFileDialog1.FileName;
                _game.SaveGame(save);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            _game.SaveGame();            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string save = openFileDialog1.FileName;
                _game.LoadGame(save);
            }

            UpdateForm();

            if (buttonBelive.Enabled != true)
            {
                SetButtons(true);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_game.IsQuestionsBaseEmpty)
            {
                OpenLoadFileWarning();
                return;
            }

            StartNewGame();
        }

        private void StartNewGame()
        {
            _game.StartNewGame();
            SetButtons(true);
            UpdateForm();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAboutWindow();
        }

        #endregion

        #region MessageBoxes


        private void OpenLoadFileWarning()
        {
            MessageBox.Show(
                "Please load questions",
                "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void OpenAboutWindow()
        {
            MessageBox.Show(
                "Gubin Andrei - Geek Brain\n" +
                "Current version: 1.0.0\n" +
                "All rights reserved - 2022",
                "About Programm",
                MessageBoxButtons.OK);            
        }

        private void OpenGameOverWindow()
        {
            if(MessageBox.Show(
                "Game is over\nWould you like to continue?", 
                "Believe or Not Believe", 
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == 
                DialogResult.Yes)
            {
                _game.StartNewGame();
            }
            else
            {
                Close();
            }
        }


        #endregion

        
    }
}
