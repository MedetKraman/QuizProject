using System;

namespace SimpleQuiz.Models {
    public sealed class StudentView : UserView {
        public StudentView(Guid id, string lastname, string firstname, string? fathername) : base(id, lastname, firstname, fathername) {
        }
    }
}
