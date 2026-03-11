
using SurveyNest.Application.DtoContracts.Answer;

namespace SurveyNest.Application.DtoContracts.Questions;


public record QuestionResponse
(
    int Id,
    string Content,
    IEnumerable<AnswerResponse> Answers







);
