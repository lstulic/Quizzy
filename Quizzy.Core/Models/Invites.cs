// <copyright file="Invites.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Models
{
    /// <summary>
    /// Invites model.
    /// </summary>
    public class Invites
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string? Username { get; set; }

        /// <summary>
        /// Gets or sets the quiz identifier.
        /// </summary>
        /// <value>
        /// The quiz identifier.
        /// </value>
        public Guid QuizId { get; set; }

        /// <summary>
        /// Gets or sets the name of the quiz.
        /// </summary>
        /// <value>
        /// The name of the quiz.
        /// </value>
        public string? QuizName { get; set; }
    }
}
