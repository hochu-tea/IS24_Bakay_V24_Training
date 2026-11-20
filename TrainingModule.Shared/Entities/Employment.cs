using System.ComponentModel.DataAnnotations;

namespace TrainingModule.Shared.Entities;

/// <summary>
/// Данные по трудоустройству выпускника (план/факт)
/// </summary>
public class Employment
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public int GroupId { get; set; }

    public DateTime? PlannedDate { get; set; }
    public DateTime? ActualDate { get; set; }

    [MaxLength(150)]
    public string? Employer { get; set; }

    [MaxLength(100)]
    public string? Position { get; set; }

    [MaxLength(20)]
    public string Status { get; set; } = "planned"; // planned, employed, unemployed

    // Навигационные свойства
    public virtual User User { get; set; } = null!;
    public virtual TrainingGroup Group { get; set; } = null!;
}