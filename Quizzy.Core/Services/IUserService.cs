// <copyright file="IUserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Services
{
    /// <summary>
    /// IUserService interface.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>List of Users.</returns>
        public Task<IEnumerable<Core.Models.User?>?> GetUsers();

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>User.</returns>
        public Task<Core.Models.User?> GetUser(Guid id);

        /// <summary>
        /// Posts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>User.</returns>
        public Task<Core.Models.User?> PostUser(Core.Models.User user);

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>User.</returns>
        public Task<Core.Models.User?> LoginUser(string username, string password);

        /// <summary>
        /// Puts the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns>Doesn't return anything.</returns>
        public Task PutUser(Guid id, Core.Models.User user);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Doesn't return anything.</returns>
        public Task DeleteUser(Guid id);

        /// <summary>
        /// Searches the users.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Returns List of Users.</returns>
        public Task<IEnumerable<Core.Models.User?>?> SearchUsers(string text);
    }
}
