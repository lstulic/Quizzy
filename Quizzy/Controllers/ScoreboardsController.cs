// <copyright file="ScoreboardsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// ScoreboardsController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreboardsController : API.Controllers.Base.ControllerBase
    {
        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreboardsController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public ScoreboardsController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }
        #endregion

        #region methods

        /// <summary>
        /// Gets the scoreboard.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of Scoreboards.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // GET: api/Scoreboards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Quizzy.Core.Models.Scoreboards?>?>> GetScoreboard(Guid id)
        {
            try
            {
                var scoreboardService = this.serviceProvider.GetRequiredService<Quizzy.Core.Services.IScoreboardService>();

                var result = await scoreboardService.GetScoreboard(id);

                if (result == null)
                {
                    return this.Error("Error occured while getting scoreboard");
                }

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }
        #endregion
    }
}
