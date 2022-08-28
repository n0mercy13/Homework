using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lesson07_Task02
{
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
        }

        private void buttonTryNumber_Click(object sender, EventArgs e)
        {
            string input = textBoxInput.Text;
            if(int.TryParse(input, out int number) && 
                IsNumberCorrect(number))
            {
                Program.MakeTurn(number);
            }
        }

        public void ResetForm()
        {
            textBoxInput.Text = String.Empty;
        }

        private bool IsNumberCorrect(int number) => number >= GuessNumber.MIN && number <= GuessNumber.MAX;
        
    }
}
