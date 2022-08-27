namespace ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

public class Trailer
{
    public int Id { get; set; }

    [MaxLength(2084)]
    public string Name { get; set; }

    [MaxLength(2084)]
    public string TrailerUrl { get; set; } 

    public int MovieId { get; set; }

    // Navigation Property
    public Movie Movie { get; set; }
    
}