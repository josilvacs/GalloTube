using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalloTube.Models;
[Table("MovieGenre")]
public class MovieGenre
{
    [Key, Column(Order = 1)]
    public int MovieId { get; set; }
    [ForeignKey("MovieId")]
    public Movie Movie { get; set; }

    [Key, Column(Order = 2)]
    public byte GenreId { get; set; }
    [ForeignKey("GenreId")]
    public Genre Genre { get; set; }
}

