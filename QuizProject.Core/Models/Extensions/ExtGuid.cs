using System;

namespace QuizProject.Core.Models {
    public static class ExtGuid {
        public static bool IsNone(this Guid id) => id == Guid.Empty;
        public static bool IsSome(this Guid id) => !id.IsNone();

        public static bool IsNone(this Guid? id) => id is null || id.Value.IsNone();
        public static bool IsSome(this Guid? id) => !id.IsNone(); } }
