// <copyright file="QuizShort.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Dto
{
    /// <summary>
    /// QuizShort DTO.
    /// </summary>
    public class QuizShort
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public int? Time { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string? Category { get; set; } = null!;

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        /// <value>
        /// The active.
        /// </value>
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string? Description { get; set; }
    }
}
