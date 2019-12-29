using System;

namespace SimpleQuiz.Models {
    public abstract class UserView {
        private readonly FIOModel FIOModel;

        public UserView(Guid id, string lastname, string firstname, string? fathername) {
            Id          = id.IsSome() ? id : throw new ArgumentNullException(nameof(id));
            FIOModel = new FIOModel(lastname, firstname, fathername);
        }

        public Guid Id { get; }

        public string Lastname => FIOModel.Lastname;
        public string Firstname => FIOModel.Firstname;
        public string? Fathername => FIOModel.Fathername;

        public string FullFIO => FIOModel.FullFIO;
        public string ShortFIO => FIOModel.ShortFIO;
    }
}
