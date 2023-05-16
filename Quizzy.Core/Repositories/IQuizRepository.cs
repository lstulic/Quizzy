// <copyright file="IQuizRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Repositories
{
    /// <summary>
    /// IQuizRepository interface.
    /// </summary>
    public interface IQuizRepository
    {
        /// <summary>
        /// Gets the quizzes.
        /// </summary>
        /// <returns>List of Quizzes.</returns>
        public Task<IEnumerable<Core.Models.Quiz?>?> GetQuizzes();

        /// <summary>
        /// Gets the quizzes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of Quizzes.</returns>
        public Task<IEnumerable<Core.Models.Quiz?>?> GetQuizzes(Guid? id);

        /// <summary>
        /// Gets the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Quiz.</returns>
        public Task<Core.Models.Quiz?> GetQuiz(Guid id);

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <returns>List of strings.</returns>
        public Task<IEnumerable<string?>?> GetCategory();

        /// <summary>
        /// Posts the quiz.
        /// </summary>
        /// <param name="quiz">The quiz.</param>
        /// <returns>Quiz.</returns>
        public Task<Core.Models.Quiz?> PostQuiz(Core.Models.Quiz quiz);

        /// <summary>
        /// Puts the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quiz">The quiz.</param>
        /// <returns>Doesn't return anything.</returns>
        public Task PutQuiz(Guid id, Core.Models.Quiz quiz);

        /// <summary>
        /// Activates the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Doesn't return anything.</returns>
        public Task<string?> ActivateQuiz(Guid id);

        /// <summary>
        /// Deletes the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Doesn't return anything.</returns>
        public Task DeleteQuiz(Guid id);

        /// <summary>
        /// Quizs the end.
        /// </summary>
        /// <param name="quizId">The quiz identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="answers">The answers.</param>
        /// <returns>Integer.</returns>
        public Task<int?> QuizEnd(Guid quizId, Guid? userId, List<Core.Models.Answer> answers);

        /// <summary>
        /// Searches the quizzes.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Quiz.</returns>
        public Task<IEnumerable<Core.Models.Quiz?>?> SearchQuizzes(string text);
    }
}
