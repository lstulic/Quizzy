// <copyright file="QuizRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Repository.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Quizzy.Core.Models;

    /// <summary>
    /// QuizRepository class.
    /// </summary>
    /// <seealso cref="Quizzy.Core.Repositories.IQuizRepository" />
    public class QuizRepository : Core.Repositories.IQuizRepository
    {
        #region attributes
        private readonly Repository.Data.StudentsQuizzyContext context;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuizRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public QuizRepository(Repository.Data.StudentsQuizzyContext context)
        {
            this.context = context;
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
            string message = string.Empty;
            if (this.context.Quizzes == null)
            {
                return null;
            }

            var quiz = await this.context.Quizzes.FindAsync(id);

            if (quiz == null)
            {
                return null;
            }

            if (quiz.Active)
            {
                quiz.Active = false;
                message = "0";
            }
            else
            {
                quiz.Active = true;
                message = "1";
            }

            this.context.Entry(quiz).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.QuizExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return message;
        }

        /// <summary>
        /// Deletes the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="System.Exception">Exception.</exception>
        /// <returns>Doesn't return anything.</returns>
        public async Task DeleteQuiz(Guid id)
        {
            if (this.context.Quizzes == null)
            {
                throw new Exception();
            }

            var quiz = await this.context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                throw new Exception();
            }

            this.context.Quizzes.Remove(quiz);
            await this.context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <returns>
        /// List of strings.
        /// </returns>
        public async Task<IEnumerable<string?>?> GetCategory()
        {
            if (this.context.Quizzes == null)
            {
                return null;
            }

            var categories = await this.context.Quizzes.Select(x => x.Category).Distinct().ToListAsync();

            return categories;
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
            if (this.context.Quizzes == null)
            {
                return null;
            }

            var quiz = await this.context.Quizzes.FindAsync(id);

            if (quiz == null)
            {
                return null;
            }

            return quiz;
        }

        /// <summary>
        /// Gets the quizzes.
        /// </summary>
        /// <returns>
        /// List of Quizzes.
        /// </returns>
        public async Task<IEnumerable<Core.Models.Quiz?>?> GetQuizzes()
        {
            if (this.context.Quizzes == null)
            {
                return null;
            }

            var quizzes = await this.context.Quizzes.ToListAsync();

            return quizzes;
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
            if (this.context.Quizzes == null)
            {
                return null;
            }

            if (id != null)
            {
                var quizzes = await this.context.Quizzes.Where(q => !this.context.Scoreboards.Any(s => s.QuizId == q.Id && s.UserId == id)).Select(q => q).Distinct().ToListAsync();

                return quizzes;
            }
            else
            {
               var quizzes = await this.context.Quizzes.ToListAsync();

               return quizzes;
            }
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
            if (this.context.Quizzes == null)
            {
                return null;
            }

            this.context.Quizzes.Add(quiz);

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (this.QuizExists(quiz.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return quiz;
        }

        /// <summary>
        /// Puts the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quiz">The quiz.</param>
        /// <exception cref="System.Exception">Exception.</exception>
        /// <returns>Doesn't return anything.</returns>
        public async Task PutQuiz(Guid id, Core.Models.Quiz quiz)
        {
            if (this.context.Quizzes == null)
            {
                throw new Exception();
            }

            this.context.Entry(quiz).State = EntityState.Modified;

            this.context.Questions.Where(q => q.QuizId.Equals(quiz.Id)).ExecuteDelete();

            for (int i = 0; i < quiz.Questions.Count(); i++)
            {
                quiz.Questions[i].Id = Guid.NewGuid();
                this.context.Add(quiz.Questions[i]);
                for (int j = 0; j < quiz.Questions[i].Answers.Count(); j++)
                {
                    quiz.Questions[i].Answers[j].Id = Guid.NewGuid();
                    this.context.Answers.Add(quiz.Questions[i].Answers[j]);
                }
            }

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.QuizExists(id))
                {
                    throw new Exception();
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Quizs the end.
        /// </summary>
        /// <param name="quizId">The quiz identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="answers">The answers.</param>
        /// <returns>
        /// Integer.
        /// </returns>
        public async Task<int?> QuizEnd(Guid quizId, Guid? userId, List<Core.Models.Answer> answers)
        {
            int score = 0;

            if (this.context.Quizzes == null)
            {
                return -1;
            }

            List<Core.Models.Question> questions = await this.context.Questions.Where(q => q.QuizId == quizId).ToListAsync();

            int[] numberA = new int[questions.Count()];

            //for (int i = 0; i < questions.Count(); i++)
            //{
            //    for (int j = 0; j < questions[i].Answers.Count(); j++)
            //    {
            //        if (questions[i].Answers[j].Correct)
            //        {
            //            if (numberA[i] == 0)
            //            {
            //                numberA[i] = 1;
            //            }
            //            else
            //            {
            //                numberA[i]++;
            //            }
            //        }
            //    }
            //}

            var result = await (from a in this.context.Answers
                         join q in this.context.Questions on a.QuestionId equals q.Id
                         join qz in this.context.Quizzes on q.QuizId equals qz.Id
                         where a.Correct == true && qz.Id == quizId
                         group a by q.Id into grouped
                         select new
                         {
                             correctCount = grouped.Count(),
                         }).ToListAsync();

            for (int i = 0; i < result.Count(); i++)
            {
                numberA[i] = result[i].correctCount;
            }

            for (int i = 0; i < questions.Count(); i++)
            {
                int br = 0;
                for (int j = 0; j < answers.Count(); j++)
                {
                    if (answers[j].QuestionId == questions[i].Id)
                    {
                        if (!questions[i].Type.Equals("Text"))
                        {
                            if (answers[j].Correct)
                            {
                                br++;
                            }
                            else
                            {
                                br -= 100;
                            }
                        }
                        else
                        {
                            if (answers[j].Text == questions[i].Answers[0].Text)
                            {
                                br++;
                            }
                        }

                        answers.RemoveAt(j);
                        j--;
                    }
                }

                if (br == numberA[i])
                {
                    score++;
                }
            }

            if (userId != null)
            {
                if (this.context.Scoreboards.Where(s => s.UserId == userId && s.QuizId == quizId).Count() < 1)
                {
                    Core.Models.Scoreboard sc = new Core.Models.Scoreboard()
                    {
                        Id = Guid.NewGuid(),
                        UserId = (Guid)userId,
                        QuizId = quizId,
                        Score = score,
                    };

                    this.context.Scoreboards.Add(sc);
                    try
                    {
                        await this.context.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        throw;
                    }
                }
                else
                {
                    return -1;
                }
            }

            return score;
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
            if (this.context.Quizzes == null)
            {
                return null;
            }

            var query = await (from q in this.context.Quizzes
                         where q.Name.Contains(text)
                         select new
                         {
                             Id = q.Id,
                             Name = q.Name,
                             Time = q.Time,
                             Category = q.Category,
                             Active = q.Active,
                             Description = q.Description,
                         }).ToListAsync();

            if (query == null)
            {
                return null;
            }

            List<Core.Models.Quiz> quizzes = new List<Core.Models.Quiz>();
            foreach (var item in query)
            {
                quizzes.Add(new Core.Models.Quiz()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Time = item.Time,
                    Category = item.Category,
                    Active = item.Active,
                    Description = item.Description,
                });
            }

            return quizzes;
        }

        private bool QuizExists(Guid id)
        {
            return (this.context.Quizzes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        #endregion
    }
}
