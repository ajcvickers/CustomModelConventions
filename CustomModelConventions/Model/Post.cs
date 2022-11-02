namespace Model;

public class Post
{
    public Post(string title, string content, DateTime publishedOn)
    {
        Title = title;
        Content = content;
        PublishedOn = publishedOn;
    }

    public int Id { get; private set; }

    [MaxLength(64)]
    public string Title { get; set; }
    public string Content { get; set; }

    public DateTime PublishedOn { get; set; }

    public Blog Blog { get; set; } = null!;

    public List<Tag> Tags { get; } = new();

    public Author? Author { get; set; }
}
