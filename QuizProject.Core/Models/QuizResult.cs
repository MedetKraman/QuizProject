using System;
using System.Linq;
using System.Collections.Generic;

namespace QuizProject.Core.Models
{
    public class QuizResult
    {
        public QuizResult(Guid studentId, string studentLastname, string studentFirstname, string studentFathername, Guid? id = null, DateTime? createAt = null) {
            this.id = id.IsSome() ? id!.Value : throw new ArgumentException($"{nameof(id)}{id} is empty", nameof(id));
            this.createAt = createAt.IsSome() ? createAt!.Value : throw new ArgumentException($"{nameof(createAt)}{createAt} is empty", nameof(createAt));
            this.studentId = studentId.IsSome() ? studentId : throw new ArgumentException($"{nameof(studentId)}{studentId} is empty", nameof(studentId));
            this.studentLastname = studentLastname ?? throw new ArgumentNullException(nameof(studentLastname));
            this.studentFirstname = studentFirstname ?? throw new ArgumentNullException(nameof(studentFirstname));
            this.studentFathername = studentFathername ?? throw new ArgumentNullException(nameof(studentFathername)); }
        private readonly Guid id;
        private readonly Guid studentId;
        private readonly string studentLastname;
        private readonly string studentFirstname;
        private readonly string studentFathername;
        private readonly DateTime createAt;


        public Guid Id => id;

        public Quiz Quiz { get; }

        public Guid StudentId => studentId;
        public string StudentLastname => studentLastname;
        public string StudentFirstname => studentFirstname;
        public string StudentFathername => studentFathername;
        public string StudentFullFIO =>
            ((studentLastname.IsSome() ? $"{studentLastname} " : string.Empty) +
            (studentFirstname.IsSome() ? $"{studentFirstname} " : string.Empty) +
            (studentFathername.IsSome() ? $"{studentFathername}" : string.Empty)).Trim();
        public string StudentShortFIO =>
            ((studentLastname.IsSome() ? $"{studentLastname} " : string.Empty) +
            (studentFirstname.IsSome() ? $"{studentFirstname[0]}. " : string.Empty) +
            (studentFathername.IsSome() ? $"{studentFathername[0]}." : string.Empty)).Trim();
        public string StudentShortname =>
            (studentLastname.IsSome(), studentFirstname.IsSome(), studentFathername.IsSome()) switch {
                (true, true, _) => $"{studentLastname} {studentFirstname}",
                (_, true, true) => $"{studentFirstname} {studentFathername}",
                (true, _, _) => studentLastname,
                (_, true, _) => studentFirstname,
                (_, _, true) => studentFathername,
                _ => string.Empty };

        public DateTime CreateAt => createAt;

        public IEnumerable<StudentAnswer> Answers { get; }

        public DateTime ClosedAt =>
            Answers.Max(a => a.CreateAt);

        public double MyScore =>
            Answers.Sum(a => a.MyScore);

        public double QuizCommonScore =>
            Quiz.QuizCommonScore;

    }
}
