using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieFlix.Data;
using MovieFlix.Entities;
using static System.Console;

WriteLine("This is the MovieFlix database");

var builder = Host.CreateApplicationBuilder();
builder.Services.AddDbContext<MovieDbContext>();

var app = builder.Build();
var context = app.Services.GetRequiredService<MovieDbContext>();

context.Database.EnsureCreated();


if (context.Movies.Any() == false)
{
    List<Movie> addMovies =
    [
        new Movie(){Title = "The Odyssey",Director = "Christoper Nolan",ReleaseYear = 2026,Duration = 173,Rating = 8.0},
        new Movie(){Title = "Model Citizen",Director = "Tag Mendillo",ReleaseYear = 2026,Duration = 93,Rating = 6.8},
        new Movie(){Title = "Hart of the Beast",Director = "David Ayer",ReleaseYear = 2026,Duration = 101,Rating = 7.3},
        new Movie(){Title = "Resident Evil",Director = "Zach Cregger",ReleaseYear = 2026,Duration = 94,Rating = 7.5},
        new Movie(){Title = "Predistination",Director = "Michael Spierig",ReleaseYear = 2014,Duration = 98,Rating = 7.4},
    ];

    await context.Movies.AddRangeAsync(addMovies);
    var affectedRows = await context.SaveChangesAsync();
    WriteLine($"Affected rows: {affectedRows}");
}
