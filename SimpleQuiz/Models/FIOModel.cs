using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleQuiz.Models {
    internal class FIOModel {
        public FIOModel(string lastname, string firstname, string? fathername) {
            Lastname    = lastname        ?? throw new ArgumentNullException(nameof(lastname));
            Firstname   = firstname       ?? throw new ArgumentNullException(nameof(firstname));
            Fathername  = fathername;
        }

        public string Lastname { get; }
        public string Firstname { get; }
        public string? Fathername { get; }

        public string FullFIO => $"{Lastname} {Firstname} {Fathername}".Trim();
        public string ShortFIO =>
            $"{Lastname} {Firstname}. {(Fathername != null && Fathername.IsSome() ? Fathername[0] + "." : string.Empty)}".Trim();
    }
}
