// <copyright file="InviteService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Service.Services
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// InviteService class.
    /// </summary>
    /// <seealso cref="Quizzy.Core.Services.IInviteService" />
    public class InviteService : Core.Services.IInviteService
    {
        #region attributes
        private IServiceProvider serviceProvider;
        private Core.Repositories.IInviteRepository inviteRepository;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InviteService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public InviteService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.inviteRepository = serviceProvider.GetRequiredService<Core.Repositories.IInviteRepository>();
        }
        #endregion

        #region methods

        /// <summary>
        /// Deactivates the invite.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Doesn't return anything.</returns>
        public async Task DeactivateInvite(Guid id)
        {
            await this.inviteRepository.DeactivateInvite(id);
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
            var result = await this.inviteRepository.GetInvites(id);

            return result;
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
            var result = await this.inviteRepository.PostInvite(inv);

            return result;
        }
        #endregion
    }
}
