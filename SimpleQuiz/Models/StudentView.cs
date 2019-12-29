using System;

namespace SimpleQuiz.Models {
    public sealed class StudentView {
        public StudentView(string nickname) {
            Nickname = nickname.IsSome() ? nickname : throw new ArgumentNullException(nameof(nickname));
        }

        public string Nickname { get; }
    }
}
