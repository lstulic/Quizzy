// <copyright file="QuestionsWithoutQuiz.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Dto
{
    /// <summary>
    /// QuestionsWithoutQuiz DTO.
    /// </summary>
    public class QuestionsWithoutQuiz
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the quiz identifier.
        /// </summary>
        /// <value>
        /// The quiz identifier.
        /// </value>
        public Guid QuizId { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string? Type { get; set; } = null!;

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string? Text { get; set; } = null!;

        /// <summary>
        /// Gets or sets the hint.
        /// </summary>
        /// <value>
        /// The hint.
        /// </value>
        public string? Hint { get; set; }

        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        /// <value>
        /// The answers.
        /// </value>
        public virtual List<AnswersWithoutQuestion> Answers { get; set; } = new List<AnswersWithoutQuestion>();
    }
}
