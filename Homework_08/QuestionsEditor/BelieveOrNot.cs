using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace QuestionsEditor
{
    #region QuestionHandler

    public class QuestionHandler
    {       
        private JsonSerializerOptions options = 
            new JsonSerializerOptions { WriteIndented = true };

        public QuestionHandler() { }        

        public async void SaveQuestionsAsync(List<Question> questions, string fileName)
        {
            using FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);         
            await JsonSerializer.SerializeAsync<List<Question>>(fs, questions, options);
            await fs.DisposeAsync();           
        }        
        
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

        public override string ToString()
        {
            return $"{Text} ({Answer})";
        }                  
    }

    #endregion
}
