using SimpleQuiz.Models;
using System;
using System.Threading.Tasks;

namespace SimpleQuiz.Interfaces {
    public interface ISimpleQuizService {

        Task<SimpleQuizView> GetBy(Guid quizId);

    }
}
