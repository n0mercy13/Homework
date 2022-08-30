using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson08_Task02
{
    public class GameState : BelieveOrNot
    {
        private const string SAVE = "QuickSave.json";

        private int _currentQuestionNum = 0;
        private int _totalQuestionNum;
        private int _correctAnswers = 0;        
        private float _successRate => 
            (float)_correctAnswers * 100 / _totalQuestionNum;

        public Action OnGameOver;
        private Question _currentQuestion;        

        public bool IsQuestionsBaseEmpty =>
            _questionsBase.Count == 0;
        public bool IsGameOver { get; private set; }

        public string GetStatus() => 
            $"Question: {_currentQuestionNum} / {_totalQuestionNum} (Success rate: {_successRate:F1}%)";

        public override void StartNewGame()
        {
            base.StartNewGame();

            _currentQuestionNum = 0;
            _totalQuestionNum = _questionsGame.Count;
            _correctAnswers = 0;
            IsGameOver = false;


            GetNextQuestion();
        }

        public void GetNextQuestion()
        { 
            if (_questionsGame.Count == 0)
            {
                OnGameOver?.Invoke();
            }
            else
            {
                _currentQuestionNum++;
                _currentQuestion = _questionsGame.Pop();
            }                       
        }

        public void CheckAnswer(bool answer)
        {
            if(answer == _currentQuestion.Answer)
            {
                _correctAnswers++;
            }

            SetGameOver();
        }        

        public void LoadGame(string saveName)
        {
            GameStateSave save = _handler.LoadSavedGame(saveName);
            _correctAnswers = save.AnsweredQuestions;
            _currentQuestionNum = save.CurrentTurn;
            _questionsBase = save.QuestionsBase;
            _questionsGame = save.QuestionsGame;
            _currentQuestion = save.CurrentQuestion;
        }

        public void SaveGame(string saveName)
        {
            var save = new GameStateSave(_currentQuestionNum, _correctAnswers, 
                _questionsGame, _questionsBase, _currentQuestion);
            _handler.SaveGameStateAsync(save, saveName);
        }

        public void SaveGame() => SaveGame(SAVE);

        public string GetQuestionText() => _currentQuestion.Text;

        private void SetGameOver()
        {
            if(_questionsGame.Count == 0)
            {
                IsGameOver = true;
            }
        }
    }
}
