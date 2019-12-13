using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizProject.Core.Models
{
    public class StudentAnswer
    {


        private Func<Question> getQuestionFunc;
        private Func<bool> isTrueFunc;
        private Func<bool> canShowTrueAnswerFunc;
        private Func<double> myScoreFunc;


        public Guid Id { get; }

        public Guid QuestionOptionId { get; }

        public DateTime CreateAt { get; }

        public IEnumerable<Guid> AnswerIds { get; set; }

        public bool SelectedOption =>
            AnswerIds.Count() > 1;

        public string? AnswerText { get; }

        public bool SelfAnswered =>
            !string.IsNullOrEmpty(AnswerText);

        public bool IsTrue => isTrueFunc.Invoke();

        public bool CanShowTrueAnswer =>
            canShowTrueAnswerFunc.Invoke();

        public Question Question =>
            getQuestionFunc.Invoke();

        public double QuestionCommonScore =>
            Question.ScoreInQuiz;

        public double MyScore =>
            myScoreFunc.Invoke();

    }
}
