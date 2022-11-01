using Microsoft.EntityFrameworkCore;

namespace Videos.App;

public class ShopContext : DbContext
{
    public DbSet<Film> Films => Set<Film>();
    public DbSet<Genre> Genres => Set<Genre>();

    public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //SeedData(builder);
    }

    private void SeedData(ModelBuilder builder)
    {
        var films = new List<Film>
        {
            new Film { Id = 1, Title = "The Shawshank Redemption", Year = 1994 },
            new Film { Id = 2, Title = "The Godfather", Year = 1972 },
            new Film { Id = 3, Title = "The Dark Knight", Year = 2008 },
            new Film { Id = 4, Title = "Forrest Gump", Year = 1994 },
            new Film { Id = 5, Title = "LOTR: The Return of the King", Year = 2003 },
            new Film { Id = 6, Title = "LOTR: The Two Towers", Year = 2002 },
            new Film { Id = 7, Title = "LOTR: The Fellowship of the Ring", Year = 2001 }
        };
        builder.Entity<Film>().HasData(films);

        var genres = new List<Genre>
        {
            new(){Id = 1, Name = "Action" },
            new(){Id = 2, Name = "Fantasy" },
            new(){Id = 3, Name = "Adventure" },
            new(){Id = 4, Name = "Crime" },
            new(){Id = 5, Name = "Romance" },
            new(){Id = 6, Name = "Drama" },
            new(){Id = 7, Name = "Horror" },
        };
        builder.Entity<Genre>().HasData(genres);
    }
}
