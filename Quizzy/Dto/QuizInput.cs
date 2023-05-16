namespace Quizzy.Dto
{
    /// <summary>
    /// QuizInput DTO.
    /// </summary>
    public class QuizInput
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string? Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public int? Time { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string? Category { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="QuizInput"/> is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if active; otherwise, <c>false</c>.
        /// </value>
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the questions.
        /// </summary>
        /// <value>
        /// The questions.
        /// </value>
        public virtual List<QuestionsWithoutQuizInput> Questions { get; set; } = new List<QuestionsWithoutQuizInput>();
    }
}
