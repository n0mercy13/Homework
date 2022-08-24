using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson07_Task02
{
    public partial class FormMain : Form
    {        
        public FormMain()
        {
            InitializeComponent();            
        }

        private void buttonPlayRestart_Click(object sender, EventArgs e)
        {
            Program.RestartGame();
            buttonPlayRestart.Text = "Restart";
        }

        public void UpdateInfoLabel(string comment)
        {
            labelInfo.Text = comment;
        }

        public void UpdateTurnLabel(int turn)
        {
            labelTurns.Text = $"Turn: {turn}";
        }

        public void UpdateNumberLabel(int number)
        {
            labelNumberInputed.Text = number.ToString();
        }

        public void ResetFrom()
        {
            labelNumberInputed.Text = "???";            
        }
    }
}
