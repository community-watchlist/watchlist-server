namespace Domain.Titles.Poster;

public class TitlePoster
{
    public TitlePosterId Id  { get; }
    public TitleId TitleId { get; private set; }
    public string OriginalFileName { get; private set; }
    public string FileUrl { get; private set; }

    public Title? Title { get; } = null;

    private TitlePoster(
        TitlePosterId id,
        TitleId titleId,
        string originalFileName,
        string fileUrl)
    {
        Id = id;
        TitleId = titleId;
        OriginalFileName = originalFileName;
        FileUrl = fileUrl;
    }

    public static TitlePoster New(
        TitlePosterId id,
        TitleId titleId,
        string originalFilename,
        string fileUrl)
    => new(id, titleId, originalFilename, fileUrl);

    public void Update(
        string originalFilename,
        string fileUrl)
    {
        OriginalFileName = originalFilename;
        FileUrl = fileUrl;
    }
}