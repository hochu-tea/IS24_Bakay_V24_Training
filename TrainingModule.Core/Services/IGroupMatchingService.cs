using TrainingModule.Shared.Models;

namespace TrainingModule.Core.Services;

public interface IGroupMatchingService
{
    /// <summary>
    /// Автоматически распределяет соискателей по группам на основе критериев
    /// </summary>
    MatchingResult MatchApplicantsToGroups(List<Applicant> applicants, List<TrainingGroup> groups);
}