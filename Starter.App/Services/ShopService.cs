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
        // Remove the throw statement and enter your code
        throw new NotImplementedException();
    }
    public async Task<List<Film>> GetFilms(bool include = true)
    {
        // Remove the throw statement and enter your code
        throw new NotImplementedException();
    }
    public async Task AddGenre(string name)
    {
        // Remove the throw statement and enter your code
        throw new NotImplementedException();
    }
    public async Task<List<Genre>> GetGenresInFilms()
    {
        try
        {
            // Remove the throw statement and enter your code
            throw new NotImplementedException();
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
            // Remove the throw statement and enter your code
            throw new NotImplementedException();
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
            // Remove the throw statement and enter your code
            throw new NotImplementedException();
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
            // Remove the throw statement and enter your code
            throw new NotImplementedException();
        }
        catch
        {
            throw;
        }
    }
}