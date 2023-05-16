// <copyright file="IScoreboardService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Services
{
    /// <summary>
    /// IScoreboardService interface.
    /// </summary>
    public interface IScoreboardService
    {
        /// <summary>
        /// Gets the scoreboard.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of Scoreboards.</returns>
        public Task<IEnumerable<Core.Models.Scoreboards?>?> GetScoreboard(Guid id);
    }
}
