


namespace SurveyNest.Application.DtoContracts.Polls;

public record PollRequest(

   string Title,
   string Summary,
   DateOnly StartsAt,
   DateOnly EndsAt




);