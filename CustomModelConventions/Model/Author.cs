namespace Model;

public class Author
{
    public Author(string name)
    {
        Name = name;
    }

    [Key]
    public string Name { get; set; }

    public List<Post> Posts { get; } = new();
}
