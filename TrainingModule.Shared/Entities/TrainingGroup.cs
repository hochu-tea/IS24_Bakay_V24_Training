using System.ComponentModel.DataAnnotations;

namespace TrainingModule.Shared.Entities;

/// <summary>
/// Учебная группа
/// </summary>
public class TrainingGroup
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [MaxLength(20)]
    public string Status { get; set; } = "forming"; // forming, active, completed, cancelled

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Навигационные свойства
    public virtual Course Course { get; set; } = null!;
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public virtual ICollection<GroupCriterion> GroupCriteria { get; set; } = new List<GroupCriterion>();
    public virtual ICollection<Employment> Employments { get; set; } = new List<Employment>();
}