

namespace SurveyNest.Domain.Entities;

public sealed class Question : AuditableEntity
{
    public int Id { get; set; }

    public string Content { get; set; } = string.Empty;

    public int PollId { get; set; }

    public bool IsActive { get; set; } = true;


    public Poll Poll { get; set; } = default!;
    public ICollection<Answer> Answers { get; set; } = []; //One To Meny "only one Question to many Answers"

    public ICollection<VoteAnswer> VoteAnswers { get; set; } = []; //One To Meny "only one Answers to many VoteAnswers"

}
