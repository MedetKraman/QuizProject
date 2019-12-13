using System;
using System.Collections.Generic;
using System.Text;

namespace QuizProject.Core.Models {
    public class QuizCreateDTO {

        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public string SubjectName { get; set; }

        public int CommonScore { get; set; }

        public List<(string qst, float qstWgt, List<string> opts, List<(string answer, float answerWgt)> answers)> Questions { get; set; }



    }
}
