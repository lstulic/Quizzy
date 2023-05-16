// <copyright file="ScoreboardService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Service.Services
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// ScoreboardService class.
    /// </summary>
    /// <seealso cref="Quizzy.Core.Services.IScoreboardService" />
    public class ScoreboardService : Core.Services.IScoreboardService
    {
        #region attributes
        private IServiceProvider serviceProvider;
        #endregion

        #region contructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreboardService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public ScoreboardService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        #endregion

        #region methods

        /// <summary>
        /// Gets the scoreboard.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// List of Scoreboards.
        /// </returns>
        public async Task<IEnumerable<Core.Models.Scoreboards?>?> GetScoreboard(Guid id)
        {
            var scoreboardRepository = this.serviceProvider.GetRequiredService<Core.Repositories.IScoreboardRepository>();

            var result = await scoreboardRepository.GetScoreboard(id);

            return result;
        }
        #endregion
    }
}
