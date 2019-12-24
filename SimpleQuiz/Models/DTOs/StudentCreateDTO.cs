using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleQuiz.Models.DTOs {
    public class StudentCreateDTO {
        public Guid Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Fathername { get; set; }
    }
}
