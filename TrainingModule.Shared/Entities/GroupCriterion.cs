using System.ComponentModel.DataAnnotations;

namespace TrainingModule.Shared.Entities;

/// <summary>
/// Связь группы с критерием комплектования (многие-ко-многим)
/// </summary>
public class GroupCriterion
{
    public int Id { get; set; }

    public int GroupId { get; set; }
    public int CriterionId { get; set; }

    [MaxLength(100)]
    public string? Value { get; set; } // например: "высшее", "18-30"

    // Навигационные свойства
    public virtual TrainingGroup Group { get; set; } = null!;
    public virtual Criterion Criterion { get; set; } = null!;
}