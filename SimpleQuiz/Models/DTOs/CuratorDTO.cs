using System;

namespace SimpleQuiz.Models.DTOs {
    public class CuratorDTO {
        public Guid Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string? Fathername { get; set; }
    }
}
