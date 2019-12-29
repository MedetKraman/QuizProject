using System;
using System.Collections.Generic;

namespace SimpleQuiz.Models.DTOs {
    public class SimpleQuizCreateDTO {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

        public List<(Guid id, string qst, List<string> opts, string answ)> Questions { get; set; }
    }
}
