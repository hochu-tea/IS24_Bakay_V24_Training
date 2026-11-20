using System.ComponentModel.DataAnnotations;
using TrainingModule.Shared.Models;

namespace TrainingModule.Shared.Entities;

/// <summary>
/// Курс обучения
/// </summary>
public class Course
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DurationHours { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int MaxStudents { get; set; }

    public int? TeacherId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Навигационные свойства
    public virtual User? Teacher { get; set; }
    public virtual ICollection<TrainingGroup> Groups { get; set; } = new List<TrainingGroup>();
}