namespace SimpleQuiz.Interfaces {
    public interface IJsonConverter {
        string ToJson(object obj);
        T FromJson<T>(string jsonStr);
    }
}
