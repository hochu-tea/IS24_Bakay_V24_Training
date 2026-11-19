namespace TrainingModule.Shared.Models;

/// <summary>
/// Соискатель, желающий пройти обучение
/// </summary>
public class Applicant
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string EducationLevel { get; set; } = string.Empty; // "среднее", "высшее" и т.д.
    public string Profession { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
}