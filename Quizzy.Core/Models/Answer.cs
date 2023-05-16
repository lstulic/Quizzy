// <copyright file="Answer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Answer model.
/// </summary>
[Table("Answer")]
public class Answer
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    [Key]
    [Column("ID")]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the question identifier.
    /// </summary>
    /// <value>
    /// The question identifier.
    /// </value>
    [Column("questionId")]
    public Guid QuestionId { get; set; }

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>
    /// The text.
    /// </value>
    [Column("text")]
    public string Text { get; set; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Answer"/> is correct.
    /// </summary>
    /// <value>
    ///   <c>true</c> if correct; otherwise, <c>false</c>.
    /// </value>
    [Column("correct")]
    public bool Correct { get; set; }

    /// <summary>
    /// Gets or sets the question.
    /// </summary>
    /// <value>
    /// The question.
    /// </value>
    [ForeignKey("QuestionId")]
    [InverseProperty("Answers")]
    public virtual Question Question { get; set; } = null!;
}
