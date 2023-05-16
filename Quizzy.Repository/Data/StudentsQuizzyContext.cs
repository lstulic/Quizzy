// <copyright file="StudentsQuizzyContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Quizzy.Repository.Data;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Database Context.
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
public partial class StudentsQuizzyContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StudentsQuizzyContext"/> class.
    /// </summary>
    /// <remarks>
    /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
    /// for more information and examples.
    /// </remarks>
    public StudentsQuizzyContext()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="StudentsQuizzyContext"/> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public StudentsQuizzyContext(DbContextOptions<StudentsQuizzyContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the answers.
    /// </summary>
    /// <value>
    /// The answers.
    /// </value>
    public virtual DbSet<Core.Models.Answer> Answers { get; set; }

    /// <summary>
    /// Gets or sets the invites.
    /// </summary>
    /// <value>
    /// The invites.
    /// </value>
    public virtual DbSet<Core.Models.Invite> Invites { get; set; }

    /// <summary>
    /// Gets or sets the questions.
    /// </summary>
    /// <value>
    /// The questions.
    /// </value>
    public virtual DbSet<Core.Models.Question> Questions { get; set; }

    /// <summary>
    /// Gets or sets the quizzes.
    /// </summary>
    /// <value>
    /// The quizzes.
    /// </value>
    public virtual DbSet<Core.Models.Quiz> Quizzes { get; set; }

    /// <summary>
    /// Gets or sets the scoreboards.
    /// </summary>
    /// <value>
    /// The scoreboards.
    /// </value>
    public virtual DbSet<Core.Models.Scoreboard> Scoreboards { get; set; }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>
    /// The users.
    /// </value>
    public virtual DbSet<Core.Models.User> Users { get; set; }

    /// <summary>
    /// Override this method to further configure the model that was discovered by convention from the entity types
    /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
    /// and re-used for subsequent instances of your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
    /// define extension methods on this object that allow you to configure aspects of the model that are specific
    /// to a given database.</param>
    /// <remarks>
    /// <para>
    /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
    /// then this method will not be run. However, it will still run when creating a compiled model.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
    /// examples.
    /// </para>
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Core.Models.Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Answer__3214EC2701F9C197");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_QuestionId");
        });

        modelBuilder.Entity<Core.Models.Invite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invite__3214EC2706C50DC3");

            entity.HasOne(d => d.Invited).WithMany(p => p.InviteInviteds)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UserId2");

            entity.HasOne(d => d.Invitter).WithMany(p => p.InviteInvitters)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UserId3");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Invites)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_QuizId3");
        });

        modelBuilder.Entity<Core.Models.Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC27A2B32915");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_QuizId1");

            entity.HasMany(p => p.Answers).WithOne(p => p.Question)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_QuestionId");
        });

        modelBuilder.Entity<Core.Models.Quiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Quiz__3214EC2756131927");

            entity.HasMany(p => p.Questions).WithOne(p => p.Quiz)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_QuizId1");
        });

        modelBuilder.Entity<Core.Models.Scoreboard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Scoreboa__3214EC27A84D146D");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Scoreboards)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_QuizId2");

            entity.HasOne(d => d.User).WithMany(p => p.Scoreboards)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UserId1");
        });

        modelBuilder.Entity<Core.Models.User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27A77D3681");
        });

        this.OnModelCreatingPartial(modelBuilder);
    }

    /// <summary>
    /// Called when [model creating partial].
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
