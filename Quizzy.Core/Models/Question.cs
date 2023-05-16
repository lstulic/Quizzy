// <copyright file="Question.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Question model.
/// </summary>
[Table("Question")]
public class Question
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
    /// Gets or sets the quiz identifier.
    /// </summary>
    /// <value>
    /// The quiz identifier.
    /// </value>
    [Column("quizId")]
    public Guid QuizId { get; set; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    /// <value>
    /// The type.
    /// </value>
    [Column("type")]
    [StringLength(20)]
    public string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>
    /// The text.
    /// </value>
    [Column("text")]
    public string Text { get; set; } = null!;

    /// <summary>
    /// Gets or sets the hint.
    /// </summary>
    /// <value>
    /// The hint.
    /// </value>
    [Column("hint")]
    [StringLength(50)]
    public string? Hint { get; set; }

    /// <summary>
    /// Gets or sets the answers.
    /// </summary>
    /// <value>
    /// The answers.
    /// </value>
    [InverseProperty("Question")]
    public virtual List<Answer> Answers { get; set; } = new List<Answer>();

    /// <summary>
    /// Gets or sets the quiz.
    /// </summary>
    /// <value>
    /// The quiz.
    /// </value>
    [ForeignKey("QuizId")]
    [InverseProperty("Questions")]
    public virtual Quiz Quiz { get; set; } = null!;
}
