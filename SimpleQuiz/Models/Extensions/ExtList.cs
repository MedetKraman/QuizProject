using System.Collections.Generic;

namespace SimpleQuiz.Models {
    public static class ExtList {
        public static bool IsNone<T>(this List<T> list) => list is null || list.Count == 0;
        public static bool IsSome<T>(this List<T> list) => !list.IsNone();
    }
}
