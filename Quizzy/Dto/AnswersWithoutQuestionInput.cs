// <copyright file="AnswersWithoutQuestionInput.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Dto
{
    /// <summary>
    /// AnswersWithoutQuestionInput DTO.
    /// </summary>
    public class AnswersWithoutQuestionInput
    {
        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string? Text { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AnswersWithoutQuestionInput"/> is correct.
        /// </summary>
        /// <value>
        ///   <c>true</c> if correct; otherwise, <c>false</c>.
        /// </value>
        public bool Correct { get; set; }
    }
}
