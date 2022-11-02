namespace Model;

public class Blog
{
    public Blog(string name)
    {
        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; set; }

    public List<Post> Posts { get; } = new();
}
