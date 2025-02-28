using ChinookDal.Model;

namespace WpfCommunityToolkit.Presentation;

/// <summary>
/// Klasse für die Darstellung eines Genres im Baum
/// </summary>
public class Genre
{
    /// <summary>
    /// Konstruktor für ein Genre
    /// </summary>
    /// <param name="genre">Das Genre aus dem DAL</param>
    /// <param name="artists">Die Artists aus dem DAL</param>
    public Genre(ChinookDal.Model.Genre genre, List<Artist> artists)
    {
        this.DatabaseGenre = genre;
        this.Artists = artists;
    }

    /// <summary>
    /// Darstellung des Genres im Baum
    /// </summary>
    public string Name { get => this.DatabaseGenre.Name; private set => this.DatabaseGenre.Name = value; }

    public ChinookDal.Model.Genre DatabaseGenre { get; set; }
    public List<Artist> Artists { get; set; }
}
