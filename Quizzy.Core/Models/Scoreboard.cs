// <copyright file="Scoreboard.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Scoreboard model.
/// </summary>
[Table("Scoreboard")]
public class Scoreboard
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
    /// Gets or sets the user identifier.
    /// </summary>
    /// <value>
    /// The user identifier.
    /// </value>
    [Column("userId")]
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the quiz identifier.
    /// </summary>
    /// <value>
    /// The quiz identifier.
    /// </value>
    [Column("quizId")]
    public Guid QuizId { get; set; }

    /// <summary>
    /// Gets or sets the score.
    /// </summary>
    /// <value>
    /// The score.
    /// </value>
    [Column("score")]
    public int Score { get; set; }

    /// <summary>
    /// Gets or sets the quiz.
    /// </summary>
    /// <value>
    /// The quiz.
    /// </value>
    [ForeignKey("QuizId")]
    [InverseProperty("Scoreboards")]
    public virtual Quiz Quiz { get; set; } = null!;

    /// <summary>
    /// Gets or sets the user.
    /// </summary>
    /// <value>
    /// The user.
    /// </value>
    [ForeignKey("UserId")]
    [InverseProperty("Scoreboards")]
    public virtual User User { get; set; } = null!;
}
