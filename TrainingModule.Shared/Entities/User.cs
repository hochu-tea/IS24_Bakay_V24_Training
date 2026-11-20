using System.ComponentModel.DataAnnotations;

namespace TrainingModule.Shared.Entities;

/// <summary>
/// Пользователь системы (соискатель, преподаватель, администратор)
/// </summary>
public class User
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? Phone { get; set; }

    public DateTime? BirthDate { get; set; }

    [MaxLength(100)]
    public string? Education { get; set; }

    [MaxLength(100)]
    public string? Profession { get; set; }

    [MaxLength(20)]
    public string Role { get; set; } = "user"; // user, teacher, admin

    public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

    // Навигационные свойства
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    public virtual ICollection<Employment> Employments { get; set; } = new List<Employment>();
}