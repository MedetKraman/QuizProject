using System;
using System.Collections.Generic;

namespace SimpleQuiz.Models.DTOs {
    public class SimpleQuizCreateDTO {
        public Guid QuizId { get; set; }
        public string QuizTitle { get; set; }
        public string QuizDesc { get; set; }

        public List<(Guid id, string qst, Dictionary<Guid, string> opts, Guid answ)> QuizQuestions { get; set; }


        public Guid CuratorId { get; set; }
        public string CuratorLastname { get; set; }
        public string CuratorFirstname { get; set; }
        public string? CuratorFathername { get; set; }
    }
}
