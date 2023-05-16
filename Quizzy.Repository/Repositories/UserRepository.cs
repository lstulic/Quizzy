// <copyright file="UserRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Repository.Repositories
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// UserRepository class.
    /// </summary>
    /// <seealso cref="Quizzy.Core.Repositories.IUserRepository" />
    public class UserRepository : Core.Repositories.IUserRepository
    {
        #region attributes
        private readonly Repository.Data.StudentsQuizzyContext context;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserRepository(Repository.Data.StudentsQuizzyContext context)
        {
            this.context = context;
        }
        #endregion

        #region methods

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.Exception">Exception.</exception>
        /// <returns>Doesn't return anything.</returns>
        public async Task DeleteUser(Guid id)
        {
            if (this.context.Users == null)
            {
                throw new Exception();
            }

            var user = await this.context.Users.FindAsync(id);

            if (user == null)
            {
                throw new Exception();
            }

            var invited = await this.context.Invites.Where(i => i.InvitedId == id).ExecuteDeleteAsync();

            this.context.Users.Remove(user);
            await this.context.SaveChangesAsync();
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
            if (this.context.Users == null)
            {
                return null;
            }

            var user = await this.context.Users.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns>
        /// List of Users.
        /// </returns>
        public async Task<IEnumerable<Core.Models.User?>?> GetUsers()
        {
            if (this.context.Users == null)
            {
                return null;
            }

            var users = await this.context.Users.ToListAsync();

            return users;
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
            if (this.context.Users == null)
            {
                return null;
            }

            var user = await this.context.Users.FirstOrDefaultAsync(e => e.Username.Equals(username) && e.Password.Equals(password));

            if (user == null)
            {
                return null;
            }

            return user;
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
            if (this.context.Users == null)
            {
                return null;
            }

            this.context.Users.Add(user);

            try
            {
                await this.context.SaveChangesAsync();
                Console.WriteLine("User Saved");
            }
            catch (DbUpdateException)
            {
                if (this.UserExists(user.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return user;
        }

        /// <summary>
        /// Puts the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        /// <exception cref="System.Exception">Exception.</exception>
        /// <returns>Doesn't return anything.</returns>
        public async Task PutUser(Guid id, Core.Models.User user)
        {
            if (id != user.Id)
            {
                throw new Exception();
            }

            this.context.Entry(user).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.UserExists(id))
                {
                    throw new Exception();
                }
                else
                {
                    throw;
                }
            }
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
            if (this.context.Users == null)
            {
                return null;
            }

            var query = await (from u in this.context.Users
                         where u.Username.Contains(text)
                         select new
                         {
                             Id = u.Id,
                             Username = u.Username,
                             Password = u.Password,
                             Admin = u.Admin,
                         }).ToListAsync();

            if (query == null)
            {
                return null;
            }

            List<Core.Models.User> users = new List<Core.Models.User>();
            foreach (var item in query)
            {
                users.Add(new Core.Models.User()
                {
                    Id = item.Id,
                    Username = item.Username,
                    Password = item.Password,
                    Admin = item.Admin,
                });
            }

            return users;
        }

        private bool UserExists(Guid id)
        {
            return (this.context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion
    }
}
