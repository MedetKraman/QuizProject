using System;

namespace QuizProject.Core.Models
{
    public static class ExtDateTime {
        public static bool IsNone(this DateTime dateTime) => dateTime == DateTime.MinValue;
        public static bool IsSome(this DateTime dateTime) => !dateTime.IsNone();

        public static bool IsNone(this DateTime? dateTime) => dateTime is null || dateTime.Value.IsNone();
        public static bool IsSome(this DateTime? dateTime) => !dateTime.IsNone(); } }
