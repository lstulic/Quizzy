// <copyright file="ScoreboardRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Repository.Repositories
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// ScereboardRepository class.
    /// </summary>
    /// <seealso cref="Quizzy.Core.Repositories.IScoreboardRepository" />
    public class ScoreboardRepository : Core.Repositories.IScoreboardRepository
    {

        #region attributes
        private readonly Repository.Data.StudentsQuizzyContext context;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreboardRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ScoreboardRepository(Repository.Data.StudentsQuizzyContext context)
        {
            this.context = context;
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
            if (this.context.Scoreboards == null || this.context.Users == null)
            {
                return null;
            }

            var sc = await (from u in this.context.Users
                      join s in this.context.Scoreboards on u.Id equals s.UserId
                      where s.QuizId == id
                      orderby s.Score descending
                      select new
                      {
                          userId = u.Id,
                          username = u.Username,
                          score = s.Score,
                      }).ToListAsync();

            if (sc == null)
            {
                return null;
            }

            List<Core.Models.Scoreboards> scoreboards = new List<Core.Models.Scoreboards>();
            foreach (var item in sc)
            {
                scoreboards.Add(new Core.Models.Scoreboards()
                {
                    UserId = item.userId,
                    Username = item.username,
                    Score = item.score,
                });
            }

            return scoreboards;
        }
        #endregion
    }
}
