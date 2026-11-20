using System.ComponentModel.DataAnnotations;

namespace TrainingModule.Shared.Entities;

/// <summary>
/// Критерий комплектования группы (возраст, образование, профессия)
/// </summary>
public class Criterion
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Навигационное свойство
    public virtual ICollection<GroupCriterion> GroupCriteria { get; set; } = new List<GroupCriterion>();
}