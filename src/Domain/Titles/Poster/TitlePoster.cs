namespace Domain.Titles.Poster;

public class TitlePoster
{
    public TitlePosterId Id  { get; }
    public TitleId TitleId { get; private set; }
    public string OriginalFilename { get; private set; }
    public string FileUrl { get; private set; }

    private TitlePoster(
        TitlePosterId id,
        TitleId titleId,
        string originalFilename,
        string fileUrl)
    {
        Id = id;
        TitleId = titleId;
        OriginalFilename = originalFilename;
        FileUrl = fileUrl;
    }

    public static TitlePoster New(
        TitlePosterId id,
        TitleId titleId,
        string originalFilename,
        string fileUrl)
    => new(id, titleId, originalFilename, fileUrl);

    public void Update(
        TitleId titleId,
        string originalFilename,
        string fileUrl)
    {
        TitleId = titleId;
        OriginalFilename = originalFilename;
        FileUrl = fileUrl;
    }
}