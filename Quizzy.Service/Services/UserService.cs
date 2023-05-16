// <copyright file="UserService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Service.Services
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// UserService class.
    /// </summary>
    /// <seealso cref="Quizzy.Core.Services.IUserService" />
    public class UserService : Core.Services.IUserService
    {
        #region attributes
        private IServiceProvider serviceProvider;
        private Core.Repositories.IUserRepository userRepository;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public UserService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.userRepository = serviceProvider.GetRequiredService<Core.Repositories.IUserRepository>();
        }
        #endregion

        #region methods

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Doesn't return anything.</returns>
        public async Task DeleteUser(Guid id)
        {
            await this.userRepository.DeleteUser(id);
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// User.
        /// </returns>
        public async Task<Core.Models.User?> GetUser(Guid id)
        {
            var result = await this.userRepository.GetUser(id);

            return result;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>
        /// List of Users.
        /// </returns>
        public async Task<IEnumerable<Core.Models.User?>?> GetUsers()
        {
            var result = await this.userRepository.GetUsers();

            return result;
        }

        /// <summary>
        /// Logins the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// User.
        /// </returns>
        public async Task<Core.Models.User?> LoginUser(string username, string password)
        {
            var result = await this.userRepository.LoginUser(username, password);

            return result;
        }

        /// <summary>
        /// Posts the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>
        /// User.
        /// </returns>
        public async Task<Core.Models.User?> PostUser(Core.Models.User user)
        {
            var result = await this.userRepository.PostUser(user);

            return result;
        }

        /// <summary>
        /// Puts the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <returns>Doesn't return anything.</returns>
        public async Task PutUser(Guid id, Core.Models.User user)
        {
            await this.userRepository.PutUser(id, user);
        }

        /// <summary>
        /// Searches the users.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        /// Returns List of Users.
        /// </returns>
        public async Task<IEnumerable<Core.Models.User?>?> SearchUsers(string text)
        {
            var result = await this.userRepository.SearchUsers(text);

            return result;
        }
        #endregion
    }
}
