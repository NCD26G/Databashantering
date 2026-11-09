using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieFlix.Data;
using MovieFlix.Entities;
using static System.Console;

WriteLine("This is the MovieFlix database");

// Skapa en ApplicationBuilder instans...
var builder = Host.CreateApplicationBuilder();
builder.Services.AddDbContext<MovieDbContext>();

var app = builder.Build();
var context = app.Services.GetRequiredService<MovieDbContext>();

context.Database.EnsureCreated();

// LINQ
// var movies = context.Movies.ToList().Count;
// WriteLine($"Number of movies in the database: {movies}");

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

    // Placera filmerna i spårningshantering av vårt context...
    await context.Movies.AddRangeAsync(addMovies);
    // Spara ner till databasen...
    var affectedRows = await context.SaveChangesAsync();

    WriteLine($"Affected rows: {affectedRows}");
}

// var foundMovie = await context.Movies.FindAsync(1);
// WriteLine($"found the movie: {foundMovie?.Title}");

// foundMovie = await context.Movies.Where(c => c.Director == "David Ayer").FirstAsync();
// WriteLine($"found the movie: {foundMovie?.Title}");

// foundMovie = await context.Movies.FirstAsync(c => c.Director == "David Ayer");
// WriteLine($"found the movie: {foundMovie?.Title}");

// foundMovie = await context.Movies.FirstAsync(c => c.Director == "Clint Eastwood");
// WriteLine($"found the movie: {foundMovie?.Title}");

// foundMovie = await context.Movies.FirstOrDefaultAsync(c => c.Director == "Clint Eastwood");
// WriteLine($"found the movie: {foundMovie?.Title}");

// Kombinera sökvillkor...
// SELECT * FROM Movies WHERE Title = 'Heart of the Beast' AND ReleaseYear = 2026
// SELECT * FROM Movies WHERE Title = 'Heart of the Beast' OR ReleaseYear = 2014
// foundMovie = await context.Movies.FirstOrDefaultAsync(c => c.Director == "David Ayer" && c.Title == "Hart of the Beast");
// WriteLine($"found the movie: {foundMovie?.Title}");

// var foundMovies = context.Movies.Where(c => c.Director == "David Ayer" || c.ReleaseYear == 2014);

// foreach (var movie in foundMovies)
// {
//     WriteLine($"Title: {movie.Title} ReleaseYear: {movie.ReleaseYear}");
// }

// var movieCount = context.Movies.ToList().Count;
// WriteLine($"Number of movies in the database: {movieCount}");

// Sortera data...
// SELECT * FROM Movies ORDER BY ASC Title
// SELECT * FROM Movies ORDER BY DESC Title
// var allMovies = await context.Movies.ToListAsync();
// var allMovies = await context.Movies.OrderBy(c => c.Title).ToListAsync();
// var allMovies = await context.Movies.OrderByDescending(c => c.Title).ToListAsync();

// foreach (var movie in allMovies)
// {
//     WriteLine($"Movie: {movie.Id} - {movie.Title}");
// }

// var query = await context.Movies.ToListAsync();

// WriteLine($"Number of movies: {query.Count}");

// var result = await context.Movies.Where(c => c.Duration > 100).ToListAsync();
// var result = await context.Movies.Where(c => c.Duration < 100).ToListAsync();
var result = await context.Movies.Where(c => c.Duration > 100 && c.Duration <= 173).ToListAsync();
foreach (var movie in result)
{
    WriteLine($"Title: {movie.Title}");
}

// Projection...
// var projectedResult = await context.Movies.Where(c => c.Id == 3)
//     .Select(c => new { c.Director, c.Title, c.ReleaseYear })
//     .FirstOrDefaultAsync();
// WriteLine(result);