namespace ApplicationCore.Entities;

public class MovieCast
{
    public int CastId { get; set; }
    public string Character { get; set; }
    public int MovieId { get; set; }

    public Cast Cast { get; set; }
    public Movie Movie { get; set; }
}