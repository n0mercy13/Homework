using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuestionsEditor
{
    public class QuestionEditor
    {
        private const string DEFAULT_FILE = "Questions.json";
        private readonly string _defaultPath;

        private List<Question> _questions;
        private QuestionHandler _handler;

        public Question this[int index] => _questions[index];
        public List<Question> Questions => _questions;

        public QuestionEditor()
        {
            _questions = new List<Question>();
            _handler = new QuestionHandler();
            _defaultPath = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory, DEFAULT_FILE);

            LoadQuestions();
            SetDummyQuestion();
        }

        private void SetDummyQuestion()
        {
            if(_questions.Count > 0)
                return;

            AddQuestion(new Question("2 x 2 = 4?", true));
            SaveQuestions();
        }

        public void AddQuestion(Question question)
        {
            _questions.Add(question);
        }

        public void EditQuestion(Question question, int index)
        {
            _questions[index] = question;
        }

        public void RemoveQuestion(int index)
        {
            if(index < 0 || index >= _questions.Count)
            {
                return;
            }

            _questions.RemoveAt(index);
        }

        public void SaveQuestions(string fileName)
        {
            _handler.SaveQuestionsAsync(_questions, fileName);
        }

        public void SaveQuestions()
        {
            SaveQuestions(_defaultPath);
        }

        public void LoadQuestions(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return;
            }

            _questions = new List<Question>(_handler.LoadQuestions(fileName));
        }

        public void LoadQuestions()
        {
            LoadQuestions(_defaultPath);
        }
    }
}
