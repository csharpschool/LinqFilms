using Microsoft.EntityFrameworkCore;

namespace Videos.App;

public class ShopService
{
    // The run-time creates an instance of the ShopContext
    // from the settings in the Program.cs file and injects
    // it into the constructor.
    private readonly ShopContext _db;
    public ShopService(ShopContext db) => _db = db;

    public async Task<List<Genre>> GetGenres(bool include = true)
    {
        if(include) _db.Genres.Include(g => g.Films).Load();
        return await _db.Genres.OrderBy(g => g.Name).ToListAsync();
    }
    public async Task<List<Film>> GetFilms(bool include = true)
    {
        if (include) _db.Films.Include(g => g.Genres).Load();
        return await _db.Films.OrderBy(g => g.Title).ToListAsync();
    }
    public async Task AddGenre(string name)
    {
        if (name == default || name.Length.Equals(0))
            throw new ArgumentException("Cannot add genre: name is too short.");

        var genre = new Genre { Name = name };

        await _db.Genres.AddAsync(genre);
        await _db.SaveChangesAsync();
    }
    public async Task<List<Genre>> GetGenresInFilms()
    {
        try
        {
            return await _db.Genres.Join(
                _db.Films,
                genre => genre.Id,
                film => film.Id,
                (genre, film) => genre)
                .Where(g => g.Films.Count > 0)
                .OrderBy(g => g.Name)
                .ToListAsync();
        }
        catch
        {
            return new();
        }
    }
    public async Task<List<Film>> FilterFilms(string filter, int skip = 0, int take = 10)
    {
        try
        {
            if (filter == default || filter.Length <= 1) return await _db.Films.ToListAsync();
            if(skip < 0) skip = 0;
            if(take < 0) take = 0;

            return await _db.Films
                .Where(f => f.Title.ToLower().Contains(filter.ToLower()))
                .Skip(skip)
                .Take(take)
                .ToListAsync();
        }
        catch
        {
            throw new Exception("Unable to filter the list.");
        }
    }
    public async Task<List<Film>> UnionFilms()
    {
        try
        {
            var films1 = _db.Films.Take(2);
            var films2 = _db.Films.Skip(4).Take(1);

            return await films1.Union(films2).ToListAsync();
        }
        catch
        {
            throw;
        }
    }
    public async Task AddFilm(string title, int year, int genreId)
    {
        try
        {
            if (title == default || title.Length.Equals(0))
                throw new ArgumentException("A film must have a title.");
            if (year < 1800)
                throw new ArgumentException("Invalid year.");

            var genre = await _db.Genres.SingleOrDefaultAsync(g => g.Id.Equals(genreId));

            if (genre == default)
                throw new ArgumentException("Invalid genre.");

            var film = new Film { Title = title, Year = year, Genres = new List<Genre>() { genre } };
            
            if (genre.Films is null) genre.Films = new List<Film>();
            genre.Films.Add(film);

            _db.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
}