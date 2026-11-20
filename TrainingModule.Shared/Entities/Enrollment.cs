using System.ComponentModel.DataAnnotations;

namespace TrainingModule.Shared.Entities;

/// <summary>
/// Запись пользователя на курс или мероприятие
/// </summary>
public class Enrollment
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public int? GroupId { get; set; }
    public int? EventId { get; set; }

    [MaxLength(20)]
    public string Status { get; set; } = "pending"; // pending, approved, rejected, completed

    public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

    // Навигационные свойства
    public virtual User User { get; set; } = null!;
    public virtual TrainingGroup? Group { get; set; }
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}