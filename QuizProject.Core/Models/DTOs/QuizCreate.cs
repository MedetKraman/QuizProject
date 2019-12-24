using System;
using System.Collections.Generic;

namespace QuizProject.Core.Models {
    public class QuizCreateDTO {

        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public string SubjectName { get; set; }

        public int CommonScore { get; set; }

        public List<Question> Questions { get; set; }


        public class Question {
            public string Text { get; set; }
            public float Weight { get; set; }

            public List<string> Options { get; set; }
            public List<(string answer, float answerWgt)> Answers { get; set; }
        }

    }
}
