namespace Videos.App;

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Film>? Films { get; set; }
}