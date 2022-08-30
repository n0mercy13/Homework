using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuestionsEditor
{
    public partial class AddQuestion : Form
    {
        public AddQuestion()
        {
            InitializeComponent();
        }               

        private void buttonAddQuestion_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxQuestionText.Text))
            {
                ShowEmptyQuestionWarning();
                return;
            }

            Program.Editor.AddQuestion(
                CreateNewQuestion());

            (Application.OpenForms[nameof(MainForm)] as MainForm)
                .RefreshQuestionList();
            
            this.Close();
        }

        private void ShowEmptyQuestionWarning()
        {
            MessageBox.Show(
                "Please define question!",
                "Empty question form",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void buttonAddCanceled_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
        
        private Question CreateNewQuestion()
        {
            string text = textBoxQuestionText.Text;
            bool answer = radioButtonTrue.Checked;

            return new Question(text, answer);
        }
    }
}
