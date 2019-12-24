using System.Collections.Generic;

namespace SimpleQuiz.Models {
    public static class ExtDict {
        public static bool IsNone<T, K>(this Dictionary<T, K> dict) => dict is null || dict.Count == 0;
        public static bool IsSome<T, K>(this Dictionary<T, K> dict) => !dict.IsNone();
    }
}
