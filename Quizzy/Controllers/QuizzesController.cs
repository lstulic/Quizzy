// <copyright file="QuizzesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Controllers
{
    using System.Diagnostics.CodeAnalysis;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using DTO = Quizzy.Dto;

    /// <summary>
    /// QuizzesController class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : API.Controllers.Base.ControllerBase
    {
        #region attributes
        private Core.Services.IQuizService quizService;
        #endregion

        #region constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="QuizzesController"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public QuizzesController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            this.quizService = serviceProvider.GetRequiredService<Core.Services.IQuizService>();
        }
        #endregion

        #region methods

        /// <summary>
        /// Gets the quizzes.
        /// </summary>
        /// <returns>List of QuizShort.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Get All Quizzes
        // GET: api/Quizzes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTO.QuizShort?>?>> GetQuizzes()
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var result = await this.quizService.GetQuizzes();

                if (result == null)
                {
                    return this.Error("Error occured while getting quizzes");
                }

                var mappedResults = mapper.Map<IEnumerable<Core.Models.Quiz>, IEnumerable<DTO.QuizShort>>(result!);

                return this.Ok(mappedResults);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the quizzes.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>List of QuizShort.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // GET: api/Quizzes/active/id
        // Get All Quizzes for User
        [HttpGet("visible")]
        public async Task<ActionResult<IEnumerable<DTO.QuizShort?>?>> GetQuizzes([AllowNull] Guid? id = null)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var result = await this.quizService.GetQuizzes(id);

                if (result == null)
                {
                    return this.Error("Error occured while getting quizzes");
                }

                var mappedResults = mapper.Map<IEnumerable<Core.Models.Quiz>, IEnumerable<DTO.QuizShort>>(result!);

                return this.Ok(mappedResults);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>QuizLong.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Get Quiz with questions
        // GET: api/Quizzes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTO.QuizLong?>> GetQuiz(Guid id)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var result = await this.quizService.GetQuiz(id);

                if (result == null)
                {
                    return this.Error("Error occured while getting a quiz");
                }

                var mappedResults = mapper.Map<Core.Models.Quiz, DTO.QuizLong>(result);

                return this.Ok(mappedResults);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <returns>List of strings.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Get All Categories
        // GET: api/Quizzes/category
        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<string?>?>> GetCategory()
        {
            try
            {
                var result = await this.quizService.GetCategory();

                if (result == null)
                {
                    return this.Error("Error occured while getting categories");
                }

                return this.Ok(result);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Posts the quiz.
        /// </summary>
        /// <param name="quiz">The quiz.</param>
        /// <returns>QuizLong.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Add Quiz
        // POST: api/Quizzes
        [HttpPost]
        public async Task<ActionResult<DTO.QuizLong?>> PostQuiz(DTO.QuizInput quiz)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var mappingResult = mapper.Map<DTO.QuizInput, Core.Models.Quiz>(quiz);

                for (int i = 0; i < quiz.Questions.Count; i++)
                {
                    var question = mapper.Map<DTO.QuestionsWithoutQuizInput, Core.Models.Question>(quiz.Questions[i]);
                    mappingResult.Questions[i] = question;

                    var answers = mapper.Map<List<DTO.AnswersWithoutQuestionInput>, List<Core.Models.Answer>>(quiz.Questions[i].Answers);
                    mappingResult.Questions[i].Answers = answers;
                }

                mappingResult.Id = Guid.NewGuid();

                var result = await this.quizService.PostQuiz(mappingResult);

                if (result == null)
                {
                    return this.Error("Error occured while post a quiz");
                }

                return this.CreatedAtAction("GetQuiz", new { id = mappingResult.Id }, quiz);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Puts the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="quiz">The quiz.</param>
        /// <returns>IActionResult.</returns>
        // Update quiz
        // PUT: api/Quizzes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz(Guid id, DTO.QuizLong quiz)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var mappingResult = mapper.Map<DTO.QuizLong, Core.Models.Quiz>(quiz);

                for (int i = 0; i < quiz.Questions.Count; i++)
                {
                    var question = mapper.Map<DTO.QuestionsWithoutQuiz, Core.Models.Question>(quiz.Questions[i]);
                    mappingResult.Questions[i] = question;

                    for (int j = 0; j < quiz.Questions[i].Answers.Count; j++)
                    {
                        var answer = mapper.Map<DTO.AnswersWithoutQuestion, Core.Models.Answer>(quiz.Questions[i].Answers[j]);
                        mappingResult.Questions[i].Answers[j] = answer;
                    }
                }

                if (id != mappingResult.Id)
                {
                    return this.BadRequest();
                }

                await this.quizService.PutQuiz(id, mappingResult);

                return this.Message("Quiz updated");
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Activates the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        // Activate/deactivate Quiz
        // PATCH: api/Quizzes/activate/5
        [HttpPatch("activate/{id}")]
        public async Task<IActionResult> ActivateQuiz(Guid id)
        {
            try
            {
                var result = await this.quizService.ActivateQuiz(id);

                return this.Message(result!);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Deletes the quiz.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        // Delete Quiz
        // DELETE: api/Quizzes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            try
            {
                await this.quizService.DeleteQuiz(id);

                return this.Message("Quiz deleted");
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Quizs the end.
        /// </summary>
        /// <param name="answers">The answers.</param>
        /// <param name="quizId">The quiz identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns>ActionResult.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Quiz end
        // POST: api/Quizzes/ended
        [HttpPost("ended")]
        public async Task<ActionResult> QuizEnd([FromBody] List<DTO.AnswersWithoutQuestion> answers, [FromQuery] Guid quizId, [AllowNull] Guid? userId = null)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var ans = mapper.Map<List<DTO.AnswersWithoutQuestion>, List<Core.Models.Answer>>(answers);

                var result = await this.quizService.QuizEnd(quizId, userId, ans);

                if (result == -1)
                {
                    return this.Error("Error occured while ending the quiz");
                }

                return this.Message(result!.ToString() !);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        /// <summary>
        /// Searches the quizzes.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>List of QuizShort.</returns>
        /// <exception cref="System.Exception">Exception.</exception>
        // Search
        // GET: api/Quizzes/search/text
        [HttpGet("search/{text}")]
        public async Task<ActionResult<IEnumerable<DTO.QuizShort?>?>> SearchQuizzes(string text)
        {
            try
            {
                var mapper = this.serviceProvider.GetRequiredService<IMapper>();

                var result = await this.quizService.SearchQuizzes(text);

                if (result == null)
                {
                    return this.Error("Error occured while searching for quizzes");
                }

                var mappedResults = mapper.Map<IEnumerable<Core.Models.Quiz>, IEnumerable<DTO.QuizShort>>(result!);

                return this.Ok(mappedResults);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }
        #endregion
    }
}
