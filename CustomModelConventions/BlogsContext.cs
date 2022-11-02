public class BlogsContext : DbContext
{
    public DbSet<Blog> Blogs => Set<Blog>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Author> Authors => Set<Author>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogs")
            .LogTo(DdlLogger.Log, new[] { RelationalEventId.CommandExecuted });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FeaturedPost>();

        modelBuilder.Entity<Post>()
            .Property(e => e.Title)
            .HasMaxLength(128);

        modelBuilder.Entity<Post>()
            .HasDiscriminator<string>("PostType")
            .HasValue<Post>("Standard")
            .HasValue<FeaturedPost>("Featured");
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Remove(typeof(ForeignKeyIndexConvention));
        configurationBuilder.Conventions.Add(_ => new MaxStringLengthConvention(256));
        configurationBuilder.Conventions.Add(_ => new DiscriminatorLengthConvention3());
    }
}
