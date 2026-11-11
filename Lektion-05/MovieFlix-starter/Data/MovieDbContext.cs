using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieFlix.Entities;

namespace MovieFlix.Data;

public class MovieDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=movies.db");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
