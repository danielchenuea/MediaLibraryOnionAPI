
namespace MediaLibrary.Domain.Entities;

public class Group : EntityBase
{
    public string GroupTitle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public IList<Book> Books { get; set; } = Enumerable.Empty<Book>().ToList();
    public IList<VideoGame> VideoGames { get; set; } = Enumerable.Empty<VideoGame>().ToList();
}
