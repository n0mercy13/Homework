using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task01
{
    public partial class Form1 : Form
    {
        private Doubler _doubler;


        public Form1()
        {
            InitializeComponent();
            _doubler = new Doubler();
            ToggleButtons();
        }

        private void StartNewGame()
        {
            _doubler.StartNewGame();
            UpdateUI();
            SetGoalMessage();
            ToggleButtons();
            ChangeStartButtonName();
        }

        private void SetGoalMessage()
        {
            labelNumberToReach.Text = $"Try to get number {_doubler.GoalNumber} in {_doubler.MinTurns} turns";
        }

        private void SetGameOverMessage()
        {
            labelNumberToReach.Text = $"Superb you get it right!";
        }

        private void UpdateUI()
        {
            labelCurrentNumber.Text = _doubler.CurrentNumber.ToString();
            labelCurrentTurn.Text = _doubler.CurrentTurn.ToString();
        }

        private void CheckIfGameOver()
        {
            if (_doubler.IsGameOver())
            {
                ToggleButtons();
                SetGameOverMessage();
                ChangeStartButtonName();
            }
        }

        private void ChangeStartButtonName()
        {
            if (_doubler.IsGameOver())
                buttonPlayRestart.Text = "Start";
            else
                buttonPlayRestart.Text = "Restart";
        }

        private void ToggleButtons()
        {
            buttonMultiplyByTwo.Enabled = !buttonMultiplyByTwo.Enabled;
            buttonPlusOne.Enabled = !buttonPlusOne.Enabled;
            buttonTurnBack.Enabled = !buttonTurnBack.Enabled;
        }

        private void buttonPlusOne_Click(object sender, EventArgs e)
        {
            _doubler.AddOneToNumber();
            UpdateUI();
            CheckIfGameOver();
        }

        private void buttonMultiplyByTwo_Click(object sender, EventArgs e)
        {
            _doubler.MultiplyByTwoNumber();
            UpdateUI();
            CheckIfGameOver();
        }

        private void buttonTurnBack_Click(object sender, EventArgs e)
        {
            _doubler.UndoTurn();
            UpdateUI();            
        }

        private void buttonPlayRestart_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }
    }
}
