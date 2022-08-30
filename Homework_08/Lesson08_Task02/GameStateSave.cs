using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08_Task02
{
    [Serializable]
    public class GameStateSave
    {
        public int CurrentTurn { get; set; }
        public int AnsweredQuestions { get; set; }
        public Question CurrentQuestion { get; set; }
        public Stack<Question> QuestionsGame { get; set; }
        public List<Question> QuestionsBase { get; set; }

        public GameStateSave(int currentTurn, int answeredQuestions, 
            Stack<Question> questionsGame, List<Question> questionsBase, 
            Question currentQuestion)
        {
            CurrentTurn = currentTurn;
            AnsweredQuestions = answeredQuestions;
            QuestionsGame = questionsGame;
            QuestionsBase = questionsBase;
            CurrentQuestion = currentQuestion;
        }

        public GameStateSave() { }
    }
}
