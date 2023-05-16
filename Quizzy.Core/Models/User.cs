// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Core.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// User model.
/// </summary>
[Index("Username", Name = "UQ__Users__F3DBC5720A340D66", IsUnique = true)]
public class User
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
    /// Gets or sets the username.
    /// </summary>
    /// <value>
    /// The username.
    /// </value>
    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    /// <summary>
    /// Gets or sets the password.
    /// </summary>
    /// <value>
    /// The password.
    /// </value>
    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="User"/> is admin.
    /// </summary>
    /// <value>
    ///   <c>true</c> if admin; otherwise, <c>false</c>.
    /// </value>
    [Column("admin")]
    public bool Admin { get; set; }

    /// <summary>
    /// Gets or sets the invite inviteds.
    /// </summary>
    /// <value>
    /// The invite inviteds.
    /// </value>
    [InverseProperty("Invited")]
    public virtual List<Invite> InviteInviteds { get; set; } = new List<Invite>();

    /// <summary>
    /// Gets or sets the invite invitters.
    /// </summary>
    /// <value>
    /// The invite invitters.
    /// </value>
    [InverseProperty("Invitter")]
    public virtual List<Invite> InviteInvitters { get; set; } = new List<Invite>();

    /// <summary>
    /// Gets or sets the scoreboards.
    /// </summary>
    /// <value>
    /// The scoreboards.
    /// </value>
    [InverseProperty("User")]
    public virtual List<Scoreboard> Scoreboards { get; set; } = new List<Scoreboard>();
}
