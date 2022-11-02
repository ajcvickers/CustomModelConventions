using var context = new BlogsContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();
