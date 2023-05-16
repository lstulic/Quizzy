// <copyright file="InviteRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Repository.Repositories
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// InviteRepository class.
    /// </summary>
    /// <seealso cref="Quizzy.Core.Repositories.IInviteRepository" />
    public class InviteRepository : Core.Repositories.IInviteRepository
    {
        #region attributes
        private readonly Repository.Data.StudentsQuizzyContext context;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InviteRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public InviteRepository(Repository.Data.StudentsQuizzyContext context)
        {
            this.context = context;
        }
        #endregion

        #region methods

        /// <summary>
        /// Deactivates the invite.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.Exception">Exception.</exception>
        /// <returns>Doesn't return anything.</returns>
        public async Task DeactivateInvite(Guid id)
        {
            if (this.context.Invites == null)
            {
                throw new Exception();
            }

            var invite = await this.context.Invites.FindAsync(id);

            if (invite == null)
            {
                throw new Exception();
            }

            invite.Active = false;

            this.context.Entry(invite).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.InviteExists(id))
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
        /// Gets the invites.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// List of Invites.
        /// </returns>
        public async Task<IEnumerable<Core.Models.Invites?>?> GetInvites(Guid id)
        {
            if (this.context.Invites == null || this.context.Users == null || this.context.Quizzes == null)
            {
                return null;
            }

            var inv = await (from u in this.context.Users
                             join i in this.context.Invites on u.Id equals i.InvitterId
                             join q in this.context.Quizzes on i.QuizId equals q.Id
                             where i.InvitedId == id && i.Active == true
                             select new
                             {
                                 id = i.Id,
                                 userId = u.Id,
                                 username = u.Username,
                                 quizId = q.Id,
                                 quizName = q.Name,
                             }).ToListAsync();

            if (inv == null)
            {
                return null;
            }

            List<Core.Models.Invites> invites = new List<Core.Models.Invites>();
            foreach (var item in inv)
            {
                invites.Add(new Core.Models.Invites()
                {
                    Id = item.id,
                    UserId = item.userId,
                    Username = item.username,
                    QuizId = item.quizId,
                    QuizName = item.quizName,
                });
            }

            return invites;
        }

        /// <summary>
        /// Posts the invite.
        /// </summary>
        /// <param name="inv">The inv.</param>
        /// <returns>
        /// Invite.
        /// </returns>
        public async Task<Core.Models.Invite?> PostInvite(Core.Models.Inviting inv)
        {
            if (this.context.Invites == null)
            {
                return null;
            }

            Guid userId = (from u in this.context.Users
                           where u.Username == inv.Username
                           select u.Id).Single();

            if (this.context.Scoreboards.Where(s => s.UserId == userId && s.QuizId == inv.QuizId).Count() > 0)
            {
                return null;
            }

            if (inv.UserId == userId)
            {
                return null;
            }

            var user = this.context.Invites?.FirstOrDefault(e => e.InvitedId.Equals(userId) && e.InvitterId.Equals(inv.UserId) && e.QuizId.Equals(inv.QuizId));

            if (user != null)
            {
                return null;
            }

            Core.Models.Invite invite = new Core.Models.Invite()
            {
                Id = Guid.NewGuid(),
                InvitedId = userId,
                InvitterId = inv.UserId,
                QuizId = inv.QuizId,
                Active = true,
            };

            this.context?.Invites?.Add(invite);
            try
            {
                await this.context!.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (this.InviteExists(invite.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return invite;
        }

        private bool InviteExists(Guid id)
        {
            return (this.context.Invites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion
    }
}
