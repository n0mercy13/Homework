using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuestionsEditor
{
    public partial class MainForm : Form
    {
        private List<Question> _currentQuestions;        

        public MainForm()
        {
            InitializeComponent();
            InitialSettingsSave();
            InitialSettingsLoad();
            RefreshQuestionList();                
        }

        #region Events
        private void buttonAddQuestion_Click(object sender, EventArgs e)
        {
            new AddQuestion().Show();
        }

        private void buttonRemoveQuestion_Click(object sender, EventArgs e)
        {
            if (listBoxQuestions.SelectedIndex == -1)
                return;

            int index = listBoxQuestions.SelectedIndex;
            Program.Editor.RemoveQuestion(index);

            RefreshQuestionList();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                Program.Editor.LoadQuestions(file);

                RefreshQuestionList();
            }            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            Program.Editor.SaveQuestions();            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                Program.Editor.SaveQuestions(file);
            }
        }    

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        public void RefreshQuestionList()
        {
            if (Program.Editor.Questions != null)
            {
                _currentQuestions = Program.Editor.Questions;
            }

            if (_currentQuestions == null)
            {
                return;
            }

            listBoxQuestions.Items.Clear();

            for (int i = 0; i < _currentQuestions.Count; i++)
            {
                string question = $"{i + 1}. {_currentQuestions[i]}";
                listBoxQuestions.Items.Add(question);
            }
        }

        private void InitialSettingsSave()
        {
            saveFileDialog1.InitialDirectory =
                            AppDomain.CurrentDomain.BaseDirectory;
            saveFileDialog1.FileName = "Questions.json";
            saveFileDialog1.DefaultExt = ".json";
            saveFileDialog1.Filter = "Json files (.json)|*.json";
        }

        private void InitialSettingsLoad()
        {
            openFileDialog1.InitialDirectory =
                            AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.FileName = "Questions.json";
            openFileDialog1.DefaultExt = ".json";
            openFileDialog1.Filter = "Json files (.json)|*.json";
        }

    }
}
