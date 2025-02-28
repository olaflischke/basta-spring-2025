using ChinookDal.Model;

namespace WpfCommunityToolkit.Infrastructure;

public class ShowArtistEditDialogMessage
{
    public ShowArtistEditDialogMessage(Artist artist)
    {
        this.Artist = artist;
    }

    public Artist Artist { get; set; }
}
