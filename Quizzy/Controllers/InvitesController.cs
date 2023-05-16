// <copyright file="InvitesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// InvitesController class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class InvitesController : API.Controllers.Base.ControllerBase
    {
        #region attributes
        private Core.Services.IInviteService inviteService;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InvitesController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public InvitesController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            this.inviteService = serviceProvider.GetRequiredService<Core.Services.IInviteService>();
        }
        #endregion

        #region methods

        /// <summary>
        /// Gets the invites.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of Invites.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Get invites for user
        // GET: api/invites/invited/5
        [HttpGet("invited/{id}")]
        public async Task<ActionResult<IEnumerable<Core.Models.Invites?>?>> GetInvites(Guid id)
        {
            try
            {
                var result = await this.inviteService.GetInvites(id);

                if (result == null)
                {
                    return this.Error("Error occured while getting invites");
                }

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Posts the invite.
        /// </summary>
        /// <param name="inv">The inv.</param>
        /// <returns>Invite.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Create invite
        // POST: api/Invites
        [HttpPost]
        public async Task<ActionResult<Core.Models.Invite?>> PostInvite([FromBody] Core.Models.Inviting inv)
        {
            try
            {
                var result = await this.inviteService.PostInvite(inv);

                if (result == null)
                {
                    return this.Error("Error occured while posting invite");
                }

                return this.Message("User invitted");
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deactivates the invite.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        // Deactivate invite
        // PATCH: api/Invites/deactivate/{id}
        [HttpPatch("deactivate/{id}")]
        public async Task<IActionResult> DeactivateInvite(Guid id)
        {
            try
            {
                await this.inviteService.DeactivateInvite(id);

                return this.Message("Invite deactivated");
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }
        #endregion
    }
}
