using System;
using System.Collections.Generic;

namespace SimpleQuiz.Models.DTOs {
    public class PassedSimpleQuizCreateDTO {
        public Guid QuizId { get; set; }
        public Guid StudentId { get; set; }
        public List<Guid> SelectAnswerIds { get; set; }
    }
}
