namespace SurveyNest.Domain.Entities;

public sealed class Vote
{
    public int Id { get; set; }

    public int PollId { get; set; }

    public string UserId { get; set; } = string.Empty;

    public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;




    public Poll Poll { get; set; } = default!; // Meny to One "Vote (Many) → Poll (One)"
    public ApplicationUser User { get; set; } = default!; // Meny To One "Meny vote and have one user  "

    public ICollection<VoteAnswer> VoteAnswers { get; set; } = []; // One to meny "One Vote has many VoteAnswers"
}
