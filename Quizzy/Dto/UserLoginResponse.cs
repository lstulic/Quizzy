// <copyright file="UserLoginResponse.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Dto
{
    /// <summary>
    /// UserLoginResponse DTO.
    /// </summary>
    public class UserLoginResponse
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
        /// Gets or sets a value indicating whether this <see cref="UserLoginResponse"/> is admin.
        /// </summary>
        /// <value>
        ///   <c>true</c> if admin; otherwise, <c>false</c>.
        /// </value>
        public bool Admin { get; set; }
    }
}
