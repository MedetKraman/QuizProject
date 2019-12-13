using QuizProject.Core.Models;
using System;
using System.Threading.Tasks;

namespace QuizProject.Core.Interfaces {

    public interface IQuizWriteService {
        Task<Quiz> GetQuiz(Guid id);
    }

    public interface IQuizService : IQuizWriteService {
        Task<Guid> CreateQuiz(QuizCreateDTO newQuiz);
    }

}
