// <copyright file="Inviting.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Models
{
    /// <summary>
    /// Inviting model.
    /// </summary>
    public class Inviting
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the quiz identifier.
        /// </summary>
        /// <value>
        /// The quiz identifier.
        /// </value>
        public Guid QuizId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string? Username { get; set; }
    }
}
