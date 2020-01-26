using SimpleQuiz.Interfaces;
using SimpleQuiz.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleQuiz.Models {
    public sealed class SimpleQuizView {

        /// <summary>
        /// 
        /// Exceptions:
        ///   ArgumentNullException
        ///   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="curator"></param>
        /// <param name="questions"></param>
        internal SimpleQuizView(Guid id, string title, string desc, CuratorView curator, List<Question> questions) {
            Id          = id.IsSome() ? id : throw new ArgumentNullException(nameof(id));
            Title       = title.IsSome() ? title : throw new ArgumentNullException(nameof(title));
            Desc        = desc                          ?? throw new ArgumentNullException(nameof(desc));
            Curator     = curator                       ?? throw new ArgumentNullException(nameof(curator));
            Questions   = questions.IsSome() ? questions : throw new ArgumentNullException(nameof(questions));
        }

        public Guid Id { get; }
        public string Title { get; }
        public string Desc { get; }
        public CuratorView Curator { get; set; }
        public List<Question> Questions { get; }

        public IEnumerable<string> QuestionTexts => Questions.Select(q => q.Text).ToList();

        public class Question {

            /// <summary>
            /// 
            /// Exceptions:
            ///   ArgumentNullException
            /// 
            /// </summary>
            /// <param name="id"></param>
            /// <param name="text"></param>
            /// <param name="options"></param>
            /// <param name="answerId"></param>
            internal Question(Guid id, string text, Dictionary<Guid, string> options, Guid answerId) {
                Id          = id;
                Text        = text.IsSome() ? text : throw new ArgumentNullException(nameof(text));
                Options     = options.IsSome() ? options : throw new ArgumentNullException(nameof(options));
                AnswerId    = answerId.IsSome() ? answerId : throw new ArgumentNullException(nameof(answerId));

                if (Options.ContainsKey(AnswerId) == false)
                    throw new ArgumentException($"{nameof(options)} не содержит {nameof(answerId)}: " +
                                                $"QuestionId: {Id}; " +
                                                $"QuestionText: {Text}; " +
                                                $"AnswerId: {AnswerId}; " +
                                                $"Options: {string.Join(';', options.Select(u => $"{{{u.Key} - {u.Value}}}"))}", nameof(options));
            }

            public Guid Id { get; }
            public string Text { get; }
            public Dictionary<Guid, string> Options { get; }
            public Guid AnswerId { get; }

            public (Guid id, string opt) Answer =>
                Options.Where(u => u.Key == AnswerId).Select(u => (u.Key, u.Value)).First();
        }


        public static SimpleQuizView From(SimpleQuizCreateDTO dto) =>
            new SimpleQuizView(
                    id: dto.QuizId,
                    title: dto.QuizTitle,
                    desc: dto.QuizDesc,
                    curator: new CuratorView(dto.CuratorId, dto.CuratorLastname, dto.CuratorFirstname, dto.CuratorFathername),
                    questions: dto.QuizQuestions.Select(qq => new Question(qq.id, qq.qst, qq.opts, qq.answ)).ToList());

    }
}
