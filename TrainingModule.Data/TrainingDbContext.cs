using Microsoft.EntityFrameworkCore;
using TrainingModule.Shared.Entities;

namespace TrainingModule.Data;

/// <summary>
/// Контекст базы данных для системы учёта обучения
/// </summary>
public class TrainingDbContext : DbContext
{
    public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<TrainingGroup> TrainingGroups { get; set; }
    public DbSet<Criterion> Criteria { get; set; }
    public DbSet<GroupCriterion> GroupCriteria { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Employment> Employments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Связь Course → TrainingGroup (один-ко-многим)
        modelBuilder.Entity<TrainingGroup>()
            .HasOne(g => g.Course)
            .WithMany(c => c.Groups)
            .HasForeignKey(g => g.CourseId)
            .OnDelete(DeleteBehavior.Restrict);

        // Связь User → Course (преподаватель)
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany()
            .HasForeignKey(c => c.TeacherId)
            .OnDelete(DeleteBehavior.SetNull);

        // Связь TrainingGroup ↔ Criterion (многие-ко-многим через GroupCriterion)
        modelBuilder.Entity<GroupCriterion>()
            .HasOne(gc => gc.Group)
            .WithMany(g => g.GroupCriteria)
            .HasForeignKey(gc => gc.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GroupCriterion>()
            .HasOne(gc => gc.Criterion)
            .WithMany(c => c.GroupCriteria)
            .HasForeignKey(gc => gc.CriterionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь Enrollment → User
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.User)
            .WithMany(u => u.Enrollments)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь Enrollment → TrainingGroup
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Group)
            .WithMany(g => g.Enrollments)
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.SetNull);

        // Связь Attendance → Enrollment
        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Enrollment)
            .WithMany(e => e.Attendances)
            .HasForeignKey(a => a.EnrollmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Связь Employment → User
        modelBuilder.Entity<Employment>()
            .HasOne(e => e.User)
            .WithMany(u => u.Employments)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Связь Employment → TrainingGroup
        modelBuilder.Entity<Employment>()
            .HasOne(e => e.Group)
            .WithMany(g => g.Employments)
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}