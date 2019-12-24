namespace SimpleQuiz.Models {
    public static class ExtStr {
        public static bool IsNone(this string str) => string.IsNullOrEmpty(str);
        public static bool IsSome(this string str) => !str.IsNone(); } }
