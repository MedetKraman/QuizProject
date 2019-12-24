using System;
using System.Collections.Generic;

namespace SimpleQuiz.Models {
    public sealed class PassedSimpleQuizView {
        internal PassedSimpleQuizView(Guid id, string quizTitle, string quizDesc, StudentView student, List<Question> questions) {
            Id          = id.IsSome() ? id : throw new ArgumentNullException(nameof(id));
            QuizTitle   = quizTitle       ?? throw new ArgumentNullException(nameof(quizTitle));
            QuizDesc    = quizDesc        ?? throw new ArgumentNullException(nameof(quizDesc));
            Student     = student         ?? throw new ArgumentNullException(nameof(student));
            Questions   = questions       ?? throw new ArgumentNullException(nameof(questions));
        }

        public Guid Id { get; }
        public string QuizTitle { get; }
        public string QuizDesc { get; }
        public StudentView Student { get; }
        public List<Question> Questions { get; }


        public class Question {
            internal Question(Guid id, string text, Dictionary<Guid, string> options, Guid answerId, Guid studentAnswerId) {
                Id              = id.IsSome()               ? id                :  throw new ArgumentNullException(nameof(id));
                Text            = text                                          ?? throw new ArgumentNullException(nameof(text));
                Options         = options                                       ?? throw new ArgumentNullException(nameof(options));
                AnswerId        = answerId.IsSome()         ? answerId          :  throw new ArgumentNullException(nameof(answerId));
                StudentAnswerId = studentAnswerId.IsSome()  ? studentAnswerId   :  throw new ArgumentNullException(nameof(studentAnswerId));
            }

            public Guid Id { get; }
            public string Text { get; }
            public Dictionary<Guid, string> Options { get; }
            public Guid AnswerId { get; }
            public Guid StudentAnswerId { get; }
        }
    }
}
