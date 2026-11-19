namespace TrainingModule.Shared.Models;

/// <summary>
/// Учебная группа
/// </summary>
public class TrainingGroup
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CourseTitle { get; set; } = string.Empty;
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public string RequiredEducation { get; set; } = string.Empty;
    public int MaxCapacity { get; set; }
    public int CurrentCount { get; set; }
}