namespace ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

public class Cast
{
    public int Id { get; set; }

    public string Gender { get; set; }
    
    [MaxLength(128)]
    public int Name { get; set; }
    
    [MaxLength(2084)]
    public string ProfilePath { get; set; }
    
    public string TmdbUrl { get; set; }

    private ICollection<MovieCast> MoviesOfGast { get; set; }
}