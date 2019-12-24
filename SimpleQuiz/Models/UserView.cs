using System;

namespace SimpleQuiz.Models {
    public abstract class UserView {
        public UserView(Guid id, string lastname, string firstname, string? fathername) {
            Id          = id.IsSome() ? id : throw new ArgumentNullException(nameof(id));
            Lastname    = lastname        ?? throw new ArgumentNullException(nameof(lastname));
            Firstname   = firstname       ?? throw new ArgumentNullException(nameof(firstname));
            Fathername  = fathername;
        }

        public Guid Id { get; }
        public string Lastname { get; }
        public string Firstname { get; }
        public string? Fathername { get; }

        public string FullFIO => $"{Lastname} {Firstname} {Fathername}".Trim();
        public string ShortFIO =>
            $"{Lastname} {Firstname}. {(Fathername.IsSome() ? Fathername[0] + "." : string.Empty)}".Trim();
    }
}
