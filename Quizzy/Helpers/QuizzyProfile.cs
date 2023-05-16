// <copyright file="QuizzyProfile.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Helpers
{
    using AutoMapper;
    using DTO = Quizzy.Dto;

    /// <summary>
    /// QuizzyProfile class.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class QuizzyProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuizzyProfile"/> class.
        /// </summary>
        public QuizzyProfile()
        {
            // ### Models to DTO

            // Users
            this.CreateMap<Core.Models.User, DTO.UserLoginResponse>();
            this.CreateMap<Core.Models.User, DTO.UserUpdate>();

            // Quiz
            this.CreateMap<Core.Models.Quiz, DTO.QuizShort>();
            this.CreateMap<Core.Models.Quiz, DTO.QuizLong>();

            // Question
            this.CreateMap<Core.Models.Question, DTO.QuestionsWithoutQuiz>();
            this.CreateMap<Core.Models.Question, DTO.QuestionsWithoutQuizInput>();

            // Answer
            this.CreateMap<Core.Models.Answer, DTO.AnswersWithoutQuestion>();
            this.CreateMap<Core.Models.Answer, DTO.AnswersWithoutQuestionInput>();

            // ### DTO to Models

            // User
            this.CreateMap<DTO.UserUpdate, Core.Models.User>();

            // Quiz
            this.CreateMap<DTO.QuizLong, Core.Models.Quiz>();
            this.CreateMap<DTO.QuizInput, Core.Models.Quiz>();

            // Question
            this.CreateMap<DTO.QuestionsWithoutQuiz, Core.Models.Question>();
            this.CreateMap<DTO.QuestionsWithoutQuizInput, Core.Models.Question>();

            // Answer
            this.CreateMap<DTO.AnswersWithoutQuestion, Core.Models.Answer>();
            this.CreateMap<DTO.AnswersWithoutQuestionInput, Core.Models.Answer>();

            // ### DTO to DTO

            // Question
            this.CreateMap<DTO.QuestionsWithoutQuiz, DTO.QuestionsWithoutQuizInput>();

            // Answer
            this.CreateMap<DTO.AnswersWithoutQuestion, DTO.AnswersWithoutQuestionInput>();
        }
    }
}
