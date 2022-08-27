using System.Net.NetworkInformation;

namespace ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations;

public class Genre
{
    public int Id { get; set; }
    
    [MaxLength(24)] 
    public string Name { get; set; }

    public ICollection<MovieGenre> MoviesOfGenre { get; set; }

}