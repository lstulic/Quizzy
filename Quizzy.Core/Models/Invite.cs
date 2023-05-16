// <copyright file="Invite.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Invite model.
/// </summary>
[Table("Invite")]
public class Invite
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
    /// Gets or sets the invited identifier.
    /// </summary>
    /// <value>
    /// The invited identifier.
    /// </value>
    [Column("invitedId")]
    public Guid InvitedId { get; set; }

    /// <summary>
    /// Gets or sets the invitter identifier.
    /// </summary>
    /// <value>
    /// The invitter identifier.
    /// </value>
    [Column("invitterId")]
    public Guid InvitterId { get; set; }

    /// <summary>
    /// Gets or sets the quiz identifier.
    /// </summary>
    /// <value>
    /// The quiz identifier.
    /// </value>
    [Column("quizId")]
    public Guid QuizId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="Invite"/> is active.
    /// </summary>
    /// <value>
    ///   <c>true</c> if active; otherwise, <c>false</c>.
    /// </value>
    [Column("active")]
    public bool Active { get; set; }

    /// <summary>
    /// Gets or sets the invited.
    /// </summary>
    /// <value>
    /// The invited.
    /// </value>
    [ForeignKey("InvitedId")]
    [InverseProperty("InviteInviteds")]
    public virtual User Invited { get; set; } = null!;

    /// <summary>
    /// Gets or sets the invitter.
    /// </summary>
    /// <value>
    /// The invitter.
    /// </value>
    [ForeignKey("InvitterId")]
    [InverseProperty("InviteInvitters")]
    public virtual User Invitter { get; set; } = null!;

    /// <summary>
    /// Gets or sets the quiz.
    /// </summary>
    /// <value>
    /// The quiz.
    /// </value>
    [ForeignKey("QuizId")]
    [InverseProperty("Invites")]
    public virtual Quiz Quiz { get; set; } = null!;
}
