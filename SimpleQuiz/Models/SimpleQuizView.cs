using System;
using System.Collections.Generic;

namespace SimpleQuiz.Models {
    public sealed class SimpleQuizView {
        internal SimpleQuizView(Guid id, string title, string desc, CuratorView curator, List<Question> questions) {
            Id          = id.IsSome() ? id : throw new ArgumentNullException(nameof(id));
            Title       = title           ?? throw new ArgumentNullException(nameof(title));
            Desc        = desc            ?? throw new ArgumentNullException(nameof(desc));
            Curator     = curator         ?? throw new ArgumentNullException(nameof(curator));
            Questions   = questions       ?? throw new ArgumentNullException(nameof(questions));
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Desc { get; }
        public CuratorView Curator { get; set; }
        public List<Question> Questions { get; }

        public class Question {
            internal Question(Guid id, string text, Dictionary<Guid, string> options, Guid answerId) {
                Id          = id;
                Text        = text                        ?? throw new ArgumentNullException(nameof(text));
                Options     = options                     ?? throw new ArgumentNullException(nameof(options));
                AnswerId    = answerId.IsSome() ? answerId : throw new ArgumentNullException(nameof(answerId));
            }

            public Guid Id { get; }
            public string Text { get; }
            public Dictionary<Guid, string> Options { get; }
            public Guid AnswerId { get; }
        }
    }
}
