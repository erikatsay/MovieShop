using System.Collections;

namespace ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    public int Id { get; set; }
    
    [MaxLength(2084)]
    public string BackdropUrl { get; set; } = null!;
    public decimal? Budget { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }
    
    [MaxLength(2084)]
    public string ImdbUrl { get; set; } = null!;
    
    [MaxLength(64)]
    public string OriginalLanguage { get; set; } = null!;
    public string Overview { get; set; } = null!;
    
    [MaxLength(2084)]
    public string PosterUrl { get; set; } = null!;
    public decimal? Price { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public decimal? Revenue { get; set; }
    public int? RunTime { get; set; }
    public string Tagline { get; set; }= null!;
    
    [MaxLength(256)]
    public string Title { get; set; } = null!;
    
    [MaxLength(2084)]
    public string TmdbUrl { get; set; } = null!;
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    
    public decimal? Rating { get; set; }
    
    public ICollection<MovieCast> CastsOfMovie { get; set; }
    public ICollection<MovieGenre> GenresOfMovie { get; set; }
    public ICollection<Trailer> Trailers { get; set; }

}