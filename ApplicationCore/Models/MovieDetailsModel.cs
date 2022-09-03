namespace ApplicationCore.Models;

public class MovieDetailsModel
{
    public MovieDetailsModel()
    {
        Genres = new List<GenreModel>();
        Trailers = new List<TrailerModel>();
        Casts = new List<CastModel>();
    }

    public int Id { get; set; }

    public string BackdropUrl { get; set; } = null!;
    public decimal? Budget { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }

    public string ImdbUrl { get; set; } = null!;

    public string OriginalLanguage { get; set; } = null!;
    public string Overview { get; set; } = null!;

    public string PosterUrl { get; set; } = null!;
    public decimal? Price { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public decimal? Revenue { get; set; }
    public int? RunTime { get; set; }
    public string Tagline { get; set; }= null!;
    
    public string Title { get; set; } = null!;

    public string TmdbUrl { get; set; } = null!;
    public DateTime? UpdatedDate { get; set; }
    public string? UpdatedBy { get; set; }
    
    public decimal? Rating { get; set; }

    public List<GenreModel> Genres { get; set; }
    public List<TrailerModel> Trailers { get; set; }
    public List<CastModel> Casts { get; set; }


}