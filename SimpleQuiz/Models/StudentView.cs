using System;

namespace SimpleQuiz.Models {
    public abstract class StudentView {
        public abstract string Nickname { get; }
    }

    internal sealed class StudentWithNick : StudentView {
        public readonly string nickname;
        internal StudentWithNick(string nickname) {
            this.nickname = nickname.IsSome() ? nickname : throw new ArgumentNullException(nameof(nickname));
        }

        public override string Nickname => throw new NotImplementedException();
    }

    internal sealed class StudentWithFIO : StudentView {
        public readonly FIOModel FIOModel;
        public StudentWithFIO(string lastname, string firstname, string? fathername) {
            FIOModel = new FIOModel(lastname, firstname, fathername);
        }

        public override string Nickname => FIOModel.FullFIO;
    }
}
