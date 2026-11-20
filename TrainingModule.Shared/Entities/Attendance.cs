using System.ComponentModel.DataAnnotations;

namespace TrainingModule.Shared.Entities;

/// <summary>
/// Отметка посещаемости занятия
/// </summary>
public class Attendance
{
    public int Id { get; set; }

    public int EnrollmentId { get; set; }

    public DateTime Date { get; set; }

    [MaxLength(20)]
    public string Status { get; set; } = "absent"; // present, absent, late, excused

    public string? Note { get; set; }

    // Навигационное свойство
    public virtual Enrollment Enrollment { get; set; } = null!;
}