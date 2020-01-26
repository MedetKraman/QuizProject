using SimpleQuiz.Interfaces;
using SimpleQuiz.Models;
using SimpleQuiz.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.QTEST.Data {
    public class DemoSimpleQuizService : ISimpleQuizService {

        public Task<SimpleQuizView> GetBy(Guid quizId) {
            SimpleQuizCreateDTO dto = new SimpleQuizCreateDTO {
                QuizId = Guid.NewGuid(),
                QuizTitle = "Quiz title",
                QuizDesc = "Quiz description",
                QuizQuestions = new List<(Guid id, string qst, Dictionary<Guid, string> opts, Guid answ)> {
                    (Guid.NewGuid(), 
                     "Question 1", 
                     new Dictionary<Guid, string> { { Guid.NewGuid(), "Option 1" }, { Guid.NewGuid(), "Option 2" }, { Guid.NewGuid(), "Option 3" }, { Guid.NewGuid(), "Option 4" } }, 
                     Guid.NewGuid()),
                },

                CuratorId = Guid.NewGuid(),
                CuratorLastname = "Kraman",
                CuratorFirstname = "Medet",
                CuratorFathername = ""
            };

            var quizView = SimpleQuizView.From(dto);

            return Task.FromResult(quizView);

        }

    }
}
