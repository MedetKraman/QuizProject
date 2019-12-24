using SimpleQuiz.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuiz.Models {
    public sealed class PassedSimpleQuizView {
        internal PassedSimpleQuizView(Guid id, string quizTitle, string quizDesc, StudentView student, List<Question> questions) {
            Id          = id.IsSome()        ? id        : throw new ArgumentNullException(nameof(id));
            QuizTitle   = quizTitle.IsSome() ? quizTitle : throw new ArgumentNullException(nameof(quizTitle));
            QuizDesc    = quizDesc                      ?? throw new ArgumentNullException(nameof(quizDesc));
            Student     = student                       ?? throw new ArgumentNullException(nameof(student));
            Questions   = questions.IsSome() ? questions : throw new ArgumentNullException(nameof(questions));
        }

        public Guid Id { get; }
        public string QuizTitle { get; }
        public string QuizDesc { get; }
        public StudentView Student { get; }
        public List<Question> Questions { get; }

        public IEnumerable<string> QuestionTexts => Questions.Select(q => q.Text).ToList();
        public int AnswersCount => Questions.Count;
        public int CorrectAnswersCount => Questions.Count(q => q.IsCorrectAnswered);
        public double CorrectAnswersShare => (double)AnswersCount / CorrectAnswersCount;
        public double CorrectAnswersPercentage => CorrectAnswersShare * 100;


        public class Question {

            private readonly IJsonConverter json;

            internal Question(IJsonConverter jsonConverter, Guid id, string text, Dictionary<Guid, string> options, Guid answerId, Guid studentAnswerId) {
                json            = jsonConverter                                 ?? throw new ArgumentNullException(nameof(jsonConverter));
                Id              = id.IsSome()               ? id                :  throw new ArgumentNullException(nameof(id));
                Text            = text.IsSome()             ? text              :  throw new ArgumentNullException(nameof(text));
                Options         = options                                       ?? throw new ArgumentNullException(nameof(options));
                AnswerId        = answerId.IsSome()         ? answerId          :  throw new ArgumentNullException(nameof(answerId));
                StudentAnswerId = studentAnswerId.IsSome()  ? studentAnswerId   :  throw new ArgumentNullException(nameof(studentAnswerId));

                if (Options.ContainsKey(AnswerId) == false)
                    throw new ArgumentException($"{nameof(options)} не содержит {nameof(answerId)}: " +
                                                $"QuestionId: {Id}; " +
                                                $"QuestionText: {Text}; " +
                                                $"AnswerId: {AnswerId}; " +
                                                $"Options: {json.ToJson(options)}", nameof(options));
                if (Options.ContainsKey(StudentAnswerId) == false)
                    throw new ArgumentException($"{nameof(options)} не содержит {nameof(StudentAnswerId)}: " +
                                                $"QuestionId: {Id}; " +
                                                $"QuestionText: {Text}; " +
                                                $"StudentAnswerId: {AnswerId}; " +
                                                $"Options: {json.ToJson(options)}", nameof(options));
            }

            public Guid Id { get; }
            public string Text { get; }
            public Dictionary<Guid, string> Options { get; }
            public Guid AnswerId { get; }
            public Guid StudentAnswerId { get; }

            public (Guid id, string opt) Answer =>
                Options.Where(u => u.Key == AnswerId).Select(u => (u.Key, u.Value)).First();
            public bool IsCorrectAnswered => AnswerId == StudentAnswerId;
        }
    }
}
