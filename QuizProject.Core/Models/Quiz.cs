using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizProject.Core.Models {
    public class Quiz {

        public Quiz(string quizName,
                    IEnumerable<Question> questions,
                    Guid? id = null,
                    string? quizDesc = null,
                    DateTime? createAt = null,
                    double quizCommonScore = 0.0) {

            if (quizCommonScore < 0)
                throw new ArgumentOutOfRangeException(
                    nameof(quizCommonScore),
                    $"{quizCommonScore} должен быть положительным");

            var quesNameGroups = questions.GroupBy(o => o.QuestionText);
            if (quesNameGroups.Any(o => o.Count() > 1))
                throw new ArgumentException(
                    "Вопросы повторяются: " +
                    string.Join("; ",
                        string.Join(", ",
                            quesNameGroups
                            .Where(og => og.Count() > 1)
                            .SelectMany(og => og
                                .Select(o => o.QuestionText)))
                    ),
                    nameof(questions));

            var quesIdGroups = questions.GroupBy(o => o.Id);
            if (quesIdGroups.Any(o => o.Count() > 1))
                throw new ArgumentException(
                    "Id вопросов повторяются: " +
                    string.Join("; ",
                        string.Join(", ",
                            quesIdGroups
                            .Where(og => og.Count() > 1)
                            .SelectMany(og => og
                                .Select(o => o.Id.ToString())
                            )
                        )
                    ),
                    nameof(questions));

            Id = id ?? Guid.Empty;
            QuizName = quizName;
            QuizDesc = quizDesc;
            CreateAt = createAt ?? DateTime.MinValue;
            Questions = questions;
        }


        public Guid Id { get; }

        public string QuizName { get; }

        public string? QuizDesc { get; }

        public double QuizCommonScore { get; }

        public DateTime CreateAt { get; }

        public IEnumerable<Question> Questions { get; }

        public bool OneAnswerQuiz =>
            Questions.All(o => o.HasOneAnswer);

        public int QuestionCount =>
            Questions.Count();

        public double QuestionWeightCount =>
            Questions.Count() == 1 ? 0.0 :
            Questions.GroupBy(q => q.WeightInQuiz).Count() == 1 ? 0.0 :
            Questions.Sum(q => q.WeightInQuiz);

    }

    public class QuizDTO {

    }
}
