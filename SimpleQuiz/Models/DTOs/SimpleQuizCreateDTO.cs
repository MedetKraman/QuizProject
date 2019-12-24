using System.Collections.Generic;

namespace SimpleQuiz.Models.DTOs {
    public class SimpleQuizCreateDTO {
        public string Title { get; set; }
        public string Desc { get; set; }

        public List<(string qst, List<string> opts, string answ)> Questions { get; set; }
    }
}
