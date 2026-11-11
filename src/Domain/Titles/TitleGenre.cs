using Domain.Genres;

namespace Domain.Titles;

public class TitleGenre
{
    public TitleId TitleId { get; }
    public GenreId GenreId { get; }

    private TitleGenre(TitleId titleId, GenreId genreId)
    {
        TitleId = titleId;
        GenreId = genreId;
    }

    public static TitleGenre New(TitleId titleId, GenreId genreId)
        => new(titleId, genreId);
}