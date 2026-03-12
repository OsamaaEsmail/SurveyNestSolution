

namespace SurveyNest.Application.Interfaces;

public interface INotificationService
{
    Task SendNewPollsNotification(int? pollId = null);

}
