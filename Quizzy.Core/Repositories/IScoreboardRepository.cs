// <copyright file="IScoreboardRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Repositories
{
    /// <summary>
    /// IScoreboardRepository interface.
    /// </summary>
    public interface IScoreboardRepository
    {
        /// <summary>
        /// Gets the scoreboard.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of Scoreboards.</returns>
        public Task<IEnumerable<Core.Models.Scoreboards?>?> GetScoreboard(Guid id);
    }
}
