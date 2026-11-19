using TrainingModule.Shared.Models;

namespace TrainingModule.Core.Services;

public class GroupMatchingService : IGroupMatchingService
{
    public MatchingResult MatchApplicantsToGroups(List<Applicant> applicants, List<TrainingGroup> groups)
    {
        var result = new MatchingResult();

        // 1. Приоритизация: сортируем соискателей (например, по дате постановки на учет)
        var sortedApplicants = applicants.OrderBy(a => a.RegistrationDate).ToList();

        foreach (var applicant in sortedApplicants)
        {
            bool isAssigned = false;

            // 2. Поиск подходящей группы
            foreach (var group in groups)
            {
                // Проверка жестких критериев
                if (applicant.Age < group.MinAge || applicant.Age > group.MaxAge) continue;
                if (applicant.EducationLevel != group.RequiredEducation) continue;

                // 3. Проверка вместимости (ограничение ресурса)
                if (group.CurrentCount >= group.MaxCapacity) continue;

                // Зачисление
                group.CurrentCount++;
                result.SuccessfulMatches.Add(new MatchRecord
                {
                    ApplicantId = applicant.Id,
                    GroupId = group.Id,
                    Reason = "Соответствует критериям и есть места"
                });
                isAssigned = true;
                break; // Переходим к следующему соискателю
            }

            if (!isAssigned)
            {
                result.FailedMatches.Add(new MatchRecord
                {
                    ApplicantId = applicant.Id,
                    GroupId = null,
                    Reason = "Нет подходящих групп или места заполнены"
                });
            }
        }

        return result;
    }
}