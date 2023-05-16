// <copyright file="AnswersWithoutQuestion.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Dto
{
    /// <summary>
    /// AnswersWithoutQuestion DTO.
    /// </summary>
    public class AnswersWithoutQuestion
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the question identifier.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        public Guid QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string? Text { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AnswersWithoutQuestion"/> is correct.
        /// </summary>
        /// <value>
        ///   <c>true</c> if correct; otherwise, <c>false</c>.
        /// </value>
        public bool Correct { get; set; }
    }
}
