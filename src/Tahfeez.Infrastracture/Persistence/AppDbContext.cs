using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tahfeez.Domain.Entities.Atendences;
using Tahfeez.Domain.Entities.Badges;
using Tahfeez.Domain.Entities.Classes;
using Tahfeez.Domain.Entities.Competitions;
using Tahfeez.Domain.Entities.EducationalContents;
using Tahfeez.Domain.Entities.GradeBook;
using Tahfeez.Domain.Entities.Messages;
using Tahfeez.Domain.Entities.MonthlyQuestions;
using Tahfeez.Domain.Entities.Payments;
using Tahfeez.Domain.Entities.Recitations;
using Tahfeez.Domain.Entities.Roles;
using Tahfeez.Domain.Entities.Salaries;
using Tahfeez.Domain.Entities.Subscriptions;
using Tahfeez.Domain.Entities.Users;

namespace Tahfeez.Infrastracture.Persistence;

public class AppDbContext : IdentityDbContext<User, Role, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Atendence> Attendances { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Salary> Salaries { get; set; }
    public DbSet<Recitation> Recitations { get; set; }
    public DbSet<Badge> Badges { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<CompetitionEntry> CompetitionEntries { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<EducationalContent> EducationalContents { get; set; }
    public DbSet<MonthlyQuestion> MonthlyQuestions { get; set; }
    public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    public DbSet<GradeBookSettings> GradeBookSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply all IEntityTypeConfiguration<T> from this assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
