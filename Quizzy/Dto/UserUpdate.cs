// <copyright file="UserUpdate.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Dto
{
    /// <summary>
    /// UserUpdate DTO.
    /// </summary>
    public class UserUpdate
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; } = null!;

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="UserUpdate"/> is admin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if admin; otherwise, <c>false</c>.
        /// </value>
        public bool Admin { get; set; }
    }
}
