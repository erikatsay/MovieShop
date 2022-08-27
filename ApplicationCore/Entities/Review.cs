namespace ApplicationCore.Entities;

public class Review
{
    public int MovieId { get; set; }
    public int UserId { get; set; }

    public Movie Movie { get; set; }
    public User User { get; set; }

    public DateTime CreateDate { get; set; }
    public int Rating { get; set; }
    public string ReviewText { get; set; }
}