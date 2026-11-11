using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieFlix.Entities;

namespace MovieFlix.Data;

public class MovieDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlite("Data Source=movies.db");
        optionsBuilder.UseNpgsql("Host=ep-wispy-salad-za36e2nh-pooler.c-2.eu-west-2.aws.neon.tech; Database=movieflixdb; Username=neondb_owner; Password=npg_zQcHAsU7Wb9l; SSL Mode=VerifyFull; Channel Binding=Require;");
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
}
