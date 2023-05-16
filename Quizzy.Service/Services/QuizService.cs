// <copyright file="QuizService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Service.Services
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// QuizService class.
    /// </summary>
    /// <seealso cref="Quizzy.Core.Services.IQuizService" />
    public class QuizService : Core.Services.IQuizService
    {
        #region attributes
        private IServiceProvider serviceProvider;
        private Core.Repositories.IQuizRepository quizRepository;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuizService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public QuizService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.quizRepository = serviceProvider.GetRequiredService<Core.Repositories.IQuizRepository>();
        }
        #endregion

        #region methods

        /// <summary>
        /// Activates the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Doesn't return anything.
        /// </returns>
        public async Task<string?> ActivateQuiz(Guid id)
        {
            var result = await this.quizRepository.ActivateQuiz(id);

            return result;
        }

        /// <summary>
        /// Deletes the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Doesn't return anything.</returns>
        public async Task DeleteQuiz(Guid id)
        {
            await this.quizRepository.DeleteQuiz(id);
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <returns>
        /// List of strings.
        /// </returns>
        public async Task<IEnumerable<string?>?> GetCategory()
        {
            var result = await this.quizRepository.GetCategory();

            return result;
        }

        /// <summary>
        /// Gets the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// Quiz.
        /// </returns>
        public async Task<Core.Models.Quiz?> GetQuiz(Guid id)
        {
            var result = await this.quizRepository.GetQuiz(id);

            return result;
        }

        /// <summary>
        /// Gets the quizzes.
        /// </summary>
        /// <returns>
        /// List of Quizzes.
        /// </returns>
        public async Task<IEnumerable<Core.Models.Quiz?>?> GetQuizzes()
        {
            var result = await this.quizRepository.GetQuizzes();

            return result;
        }

        /// <summary>
        /// Gets the quizzes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// List of Quizzes.
        /// </returns>
        public async Task<IEnumerable<Core.Models.Quiz?>?> GetQuizzes(Guid? id)
        {
            var result = await this.quizRepository.GetQuizzes(id);

            return result;
        }

        /// <summary>
        /// Posts the quiz.
        /// </summary>
        /// <param name="quiz">The quiz.</param>
        /// <returns>
        /// Quiz.
        /// </returns>
        public async Task<Core.Models.Quiz?> PostQuiz(Core.Models.Quiz quiz)
        {
            var result = await this.quizRepository.PostQuiz(quiz);

            return result;
        }

        /// <summary>
        /// Puts the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quiz">The quiz.</param>
        /// <returns>Doesn't return anything.</returns>
        public async Task PutQuiz(Guid id, Core.Models.Quiz quiz)
        {
            await this.quizRepository.PutQuiz(id, quiz);
        }

        /// <summary>
        /// Quizs the end.
        /// </summary>
        /// <param name="quizId">The quiz identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="answers">The answers.</param>
        /// <returns>Integer.</returns>
        public async Task<int?> QuizEnd(Guid quizId, Guid? userId, List<Core.Models.Answer> answers)
        {
            var result = await this.quizRepository.QuizEnd(quizId, userId, answers);

            return result;
        }

        /// <summary>
        /// Searches the quizzes.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        /// Quiz.
        /// </returns>
        public async Task<IEnumerable<Core.Models.Quiz?>?> SearchQuizzes(string text)
        {
            var result = await this.quizRepository.SearchQuizzes(text);

            return result;
        }
        #endregion
    }
}
