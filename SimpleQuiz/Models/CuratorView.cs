using System;

namespace SimpleQuiz.Models {
    public sealed class CuratorView : UserView {
        public CuratorView(Guid id, string lastname, string firstname, string? fathername) : base(id, lastname, firstname, fathername) {
        }
    }
}
