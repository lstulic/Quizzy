// <copyright file="Quiz.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Quiz model.
/// </summary>
[Table("Quiz")]
[Index("Name", Name = "UQ__Quiz__72E12F1B67BADCA3", IsUnique = true)]
public class Quiz
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
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the time.
    /// </summary>
    /// <value>
    /// The time.
    /// </value>
    [Column("time")]
    public int Time { get; set; }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    /// <value>
    /// The category.
    /// </value>
    [Column("category")]
    [StringLength(20)]
    public string Category { get; set; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Quiz"/> is active.
    /// </summary>
    /// <value>
    ///   <c>true</c> if active; otherwise, <c>false</c>.
    /// </value>
    [Column("active")]
    public bool Active { get; set; }

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    /// <value>
    /// The description.
    /// </value>
    [Column("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the invites.
    /// </summary>
    /// <value>
    /// The invites.
    /// </value>
    [InverseProperty("Quiz")]
    public virtual List<Invite> Invites { get; set; } = new List<Invite>();

    /// <summary>
    /// Gets or sets the questions.
    /// </summary>
    /// <value>
    /// The questions.
    /// </value>
    [InverseProperty("Quiz")]
    public virtual List<Question> Questions { get; set; } = new List<Question>();

    /// <summary>
    /// Gets or sets the scoreboards.
    /// </summary>
    /// <value>
    /// The scoreboards.
    /// </value>
    [InverseProperty("Quiz")]
    public virtual List<Scoreboard> Scoreboards { get; set; } = new List<Scoreboard>();
}
