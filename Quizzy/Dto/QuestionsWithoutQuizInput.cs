// <copyright file="QuestionsWithoutQuizInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Dto
{
    /// <summary>
    /// QuestionsWithoutQuizInput DTO.
    /// </summary>
    public class QuestionsWithoutQuizInput
    {
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
        public virtual List<AnswersWithoutQuestionInput> Answers { get; set; } = new List<AnswersWithoutQuestionInput>();
    }
}
