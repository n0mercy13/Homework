using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Lesson08_Task02
{
    #region BelieveOrNot

    public class BelieveOrNot
    {
        protected List<Question> _questionsBase;
        protected Stack<Question> _questionsGame;
        protected QuestionHandler _handler;
        private Random _random;

        public BelieveOrNot()
        {
            _random = new Random();
            _handler = new QuestionHandler();      
            _questionsGame = new Stack<Question>();
            _questionsBase = new List<Question>();
        }

        public void SaveQuestions(List<Question> questions)
        {
            _handler.SaveQuestions(questions);
        }

        public virtual void StartNewGame()
        {            
            GetRandomGameQuestions();
        }

        public void LoadQuestionsBase(string fileName)
        {
            _questionsBase = new List<Question>(_handler.LoadQuestions(fileName));
        }

        private void GetRandomGameQuestions() => GetRandomGameQuestions(5);

        private void GetRandomGameQuestions(int numberOfQuestions)
        {
            if(_questionsGame != null)
                _questionsGame.Clear();

            int[] randomIndexes = GetRandomIndexes(numberOfQuestions);
            GetGameQuestions(randomIndexes);
        }

        private void GetGameQuestions(int[] randomIndexes)
        {
            foreach (int index in randomIndexes)
            {
                Question questionToAdd = _questionsBase[index];
                _questionsGame.Push(questionToAdd);
            }
        }

        private int[] GetRandomIndexes(int arrayLenght)
        {
            return Enumerable
                .Range(0,_questionsBase.Count)
                .OrderBy(index => _random.Next())
                .Take(arrayLenght)
                .ToArray();
        }
    }

    #endregion

    #region QuestionHandler

    public class QuestionHandler
    {
        private List<Question> _questions = new List<Question>();
        private const string FILE = "Questions.json";
        private JsonSerializerOptions options = 
            new JsonSerializerOptions { WriteIndented = true };

        public QuestionHandler() { }

        public void SaveQuestions(List<Question> questions)
        {
            var json = JsonSerializer.Serialize<List<Question>>(questions, options);
            File.WriteAllText(FILE, json);
        }

        public async void SaveGameStateAsync(GameStateSave save, string saveName)
        {
            using FileStream fs = new FileStream(saveName, FileMode.OpenOrCreate, FileAccess.Write);         
            await JsonSerializer.SerializeAsync<GameStateSave>(fs, save, options);
            await fs.DisposeAsync();           
        }

        public List<Question> LoadQuestions() => LoadQuestions(FILE);
        
        public List<Question> LoadQuestions(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            string json = File.ReadAllText(fileName);
            List<Question> questions = JsonSerializer.Deserialize<List<Question>>(json);

            return questions;
        }

        public GameStateSave LoadSavedGame(string saveName)
        {
            if (!File.Exists(saveName))
            {
                throw new FileNotFoundException(saveName);
            }

            string json = File.ReadAllText(saveName);
            GameStateSave save = JsonSerializer.Deserialize<GameStateSave>(json);

            return save;
        }

        public async void LoadQuestionsAsync(string fileName)
        {
            using FileStream openStream = File.OpenRead(fileName);
            List<Question> questions =
                await JsonSerializer.DeserializeAsync<List<Question>>(openStream);

            _questions.AddRange(questions);
        }

        public void LoadQuestionsAsync() => LoadQuestionsAsync(FILE);

        public List<Question> GetQuestions() => _questions;        
    }

    #endregion

    #region Question

    [Serializable]
    public class Question
    {        
        public string Text { get; set; }
        public bool Answer { get; set; }              

        public Question(string text, bool answer)
        {
            Text = text;
            Answer = answer;            
        }       
        
        public Question()
        {
            
        }
    }

    #endregion
}
