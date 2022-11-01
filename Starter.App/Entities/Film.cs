namespace Videos.App;

public class Film
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public virtual ICollection<Genre>? Genres { get; set; }
}