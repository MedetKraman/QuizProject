using System;

namespace QuizProject.Core.Models
{
    public class QuestionOption
    {

        public QuestionOption(string optionText,
                              Guid? id = null,
                              bool isAnswer = false,
                              double weightInQuestion = 0.0)
        {

            if (weightInQuestion < 0.0)
                throw new ArgumentOutOfRangeException(
                    nameof(weightInQuestion),
                    $"{weightInQuestion} должен быть положительным");

            if (id is null)
                id = Guid.Empty;

            (Id, OptionText, IsAnswer, WeightInQuestion) = (id.Value, optionText, isAnswer, weightInQuestion);
        }

        public Guid Id { get; }

        public string OptionText { get; }

        public bool IsAnswer { get; }

        public double WeightInQuestion { get; set; }

    }
}
