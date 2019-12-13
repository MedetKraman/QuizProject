using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizProject.Core.Models
{
    public class Question
    {

        private readonly Func<double> scoreInQuizFunc;

        
        public Question(string questionText,
                        Func<double> scoreInQuizFunc,
                        Guid? id = null,
                        double weightInQuiz = 0.0,
                        IEnumerable<QuestionOption>? options = null)
        {

            if (weightInQuiz < 0.0)
                throw new ArgumentOutOfRangeException(
                    nameof(weightInQuiz),
                    $"{weightInQuiz} должен быть положительным");

            var optQuesGroups = options.GroupBy(o => o.OptionText);
            if (optQuesGroups.Any(o => o.Count() > 1))
                throw new ArgumentException(
                    "Ответы повторяются: " + 
                    string.Join("; ",
                        string.Join(", ",
                            optQuesGroups
                            .Where(og => og.Count() > 1)
                            .SelectMany(og => og
                                .Select(o => o.OptionText)
                            )
                        )
                    ), 
                    nameof(options));

            var optIdGroups = options.GroupBy(o => o.Id);
            if (optIdGroups.Any(o => o.Count() > 1))
                throw new ArgumentException(
                    "Id ответов повторяются: " + 
                    string.Join("; ",
                        string.Join(", ",
                            optIdGroups
                            .Where(og => og.Count() > 1)
                            .SelectMany(og => og
                                .Select(o => o.Id.ToString())
                            )
                        )
                    ), 
                    nameof(options));

            if (id is null)
                id = Guid.Empty;

            Id = id.Value;
            QuestionText = questionText;
            WeightInQuiz = weightInQuiz;
            this.scoreInQuizFunc = scoreInQuizFunc;
            Options = options ?? Array.Empty<QuestionOption>();
        }


        public Guid Id { get; }

        public string QuestionText { get; }

        public double WeightInQuiz { get; }

        public double ScoreInQuiz =>
            scoreInQuizFunc.Invoke();

        public IEnumerable<QuestionOption> Options { get; }

        public bool HasOneAnswer =>
            Options.Count(o => o.IsAnswer) == 1;

        public bool HasAnswer =>
            Options.Any(o => o.IsAnswer);

        public bool HasManyAnswers =>
            Options.Count(o => o.IsAnswer) > 1;

        public int AnswerCount =>
            Options.Count(o => o.IsAnswer);

        public int OptionCount =>
            Options.Count();

        public double OptionWeightCount =>
            Options.Count() == 1 ? 0.0 :
            Options.GroupBy(q => q.WeightInQuestion).Count() == 1 ? 0.0 :
            Options.Sum(q => q.WeightInQuestion);

    }

}
