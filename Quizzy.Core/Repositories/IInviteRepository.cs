// <copyright file="IInviteRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Repositories
{
    /// <summary>
    /// IInviteRepository interface.
    /// </summary>
    public interface IInviteRepository
    {
        /// <summary>
        /// Gets the invites.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of Invites.</returns>
        public Task<IEnumerable<Core.Models.Invites?>?> GetInvites(Guid id);

        /// <summary>
        /// Posts the invite.
        /// </summary>
        /// <param name="inv">The inv.</param>
        /// <returns>Invite.</returns>
        public Task<Core.Models.Invite?> PostInvite(Core.Models.Inviting inv);

        /// <summary>
        /// Deactivates the invite.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Doesn't return anything.</returns>
        public Task DeactivateInvite(Guid id);
    }
}
