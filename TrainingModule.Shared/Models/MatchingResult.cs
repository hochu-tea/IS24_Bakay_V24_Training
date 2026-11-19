namespace TrainingModule.Shared.Models;

/// <summary>
/// Результат работы алгоритма комплектования
/// </summary>
public class MatchingResult
{
    public List<MatchRecord> SuccessfulMatches { get; set; } = new();
    public List<MatchRecord> FailedMatches { get; set; } = new();
}

public class MatchRecord
{
    public int ApplicantId { get; set; }
    public int? GroupId { get; set; }
    public string Reason { get; set; } = string.Empty;
}