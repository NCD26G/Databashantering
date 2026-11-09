namespace MovieFlix.Entities;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Director { get; set; }
    public int ReleaseYear { get; set; }
    public int Duration { get; set; }
    public double Rating { get; set; }
}
