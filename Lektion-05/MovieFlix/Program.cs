using Microsoft.EntityFrameworkCore;
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

// context.Database.EnsureCreated();

if (context.Movies.Any() == false)
{
    List<Movie> addMovies =
    [
        new Movie(){Title = "The Odyssey",Director = "Christoper Nolan",ReleaseYear = 2026,Duration = 173,Rating = 8.0},
        new Movie(){Title = "Model Citizen",Director = "Tag Mendillo",ReleaseYear = 2026,Duration = 93,Rating = 6.8},
        new Movie(){Title = "Hart of the Beast",Director = "David Ayer",ReleaseYear = 2026,Duration = 101,Rating = 7.3},
        new Movie(){Title = "Resident Evil",Director = "Zach Cregger",ReleaseYear = 2026,Duration = 94,Rating = 7.5},
        new Movie(){Title = "Predestination",Director = "Michael Spierig",ReleaseYear = 2014,Duration = 98,Rating = 7.4},
        new Movie(){Title = "Harry Potter och De Vises Sten",Director = "Chris Columbus",ReleaseYear = 2001,Duration = 146,Rating = 7.7},
        new Movie(){Title = "Flight Risk",Director = "Mel Gibson",ReleaseYear = 2025,Duration = 97,Rating = 5.2},
        new Movie(){Title = "21 Bridges",Director = "Brian Kirk",ReleaseYear = 2019,Duration = 95,Rating = 6.7},
        new Movie(){Title = "The Proposal",Director = "Anne Fletcher",ReleaseYear = 2009,Duration = 103,Rating = 6.8},
        new Movie(){Title = "Bridget Jones dagbok",Director = "Sharon Maguire",ReleaseYear = 2001,Duration = 92,Rating = 6.8},
    ];

    await context.Movies.AddRangeAsync(addMovies);
    var affectedRows = await context.SaveChangesAsync();
    WriteLine($"Affected rows: {affectedRows}");
}

/* LINQ Language Integrated Query */
// LINQ Queries
// SELECT title from movie
// var query = from m in context.Movies
//             select new Movie { Id = m.Id, Title = m.Title, Director = m.Director, ReleaseYear = m.ReleaseYear };

/* 
    SELECT id, title, director, releaseYear FROM movies
*/

// query = query.OrderBy(c => c.Title);
/* 
    SELECT id, title, director, releaseYear 
        FROM movies
    ORDER BY title, releaseYear ASC
*/

// query = query.OrderBy(c => c.Title).ThenByDescending(c => c.ReleaseYear);
// query = query.OrderBy(c => c.Title).ThenBy(c => c.ReleaseYear);
/* 
    SELECT id, title, director, releaseYear 
        FROM movies
    ORDER BY title ASC
*/

// Fråga körs inte förrän vi använder ToList();
// var movies = await query.ToListAsync();
// foreach (var movie in movies)
// {
//     WriteLine($"{movie.Id} {movie.Title} {movie.Director} {movie.ReleaseYear}");
// }

// WriteLine("-----------------------------------------------");
// query = query.Where(c => c.Director == "Zach Cregger");

// var foundMovie = await query.FirstOrDefaultAsync();

// if (foundMovie is not null)
// {
//     WriteLine($"Found Oliver favourite director : {foundMovie.Title}");
// }
// else
// {
//     WriteLine("Kunde inte hitta Olivers favorit regissör");
// }

// LINQ Methods
// var movies = await context.Movies
//     .Select(m => new Movie { Id = m.Id, Title = m.Title, Director = m.Director, ReleaseYear = m.ReleaseYear })
//     .ToListAsync(); // Frågan körs här!!!

// var movies = await context.Movies
//     .Select(m => new Movie { Id = m.Id, Title = m.Title, Director = m.Director, ReleaseYear = m.ReleaseYear })
//     .OrderByDescending(c => c.Title)
//     .ToListAsync(); // Frågan körs här!!!


// WriteLine($"Movies in our database: {movies.Count}");

// foreach (var movie in movies)
// {
//     WriteLine($"Title: {movie.Title}");
// }

// var movieCount = await context.Movies.CountAsync(); // Frågan körs här!!!

// WriteLine($"Number of movies in our database: {movieCount}");

// var oliversMovie = await context.Movies
//     .Where(c => c.Director == "Zach Cregger")
//     .FirstOrDefaultAsync();

// if (oliversMovie is not null)
// {
//     WriteLine($"Found olivers movie: {oliversMovie.Title}");
// }

// var foundMovie = await context.Movies
//     .FirstOrDefaultAsync(c => c.Director == "Zach Cregger");

// if (foundMovie != null)
// {
//     Write($"Found the movie: {foundMovie.Title}");
// }

// var anotherMovie = await context.Movies
//     .SingleOrDefaultAsync(c => c.Director == "Zach Cregger");

// if (anotherMovie != null)
// {
//     Write($"Found the movie: {anotherMovie.Title}\n");
// }

// WriteLine("----------------------------------------------------");
// // Use pagination...
// var pagedResult = await context.Movies.Skip(1).Take(3).ToListAsync();

// foreach (var movie in pagedResult)
// {
//     WriteLine($"Title: {movie.Title}");
// }

/* LÄGGA TILL NYA FILMER */
// Steg 1. Skapa ett objekt för filmen
// var newMovie = new Movie()
// {
//     Title = "Mystic River",
//     Director = "Clint Eastwood",
//     ReleaseYear = 2003,
//     Duration = 132,
//     Rating = 7.9
// };

// // Steg 2. Addera filmen till listan Movies => Lägger i ChangeTracker för databasen...
// await context.Movies.AddAsync(newMovie);

// WriteLine($"Movies in our database: {await context.Movies.CountAsync()}");

// // Steg 3. Spara ner filmen till databasen...
// var numberOfRows = await context.SaveChangesAsync();

// WriteLine($"Movies in our database: {await context.Movies.CountAsync()}, affected rows: {numberOfRows}");

/* Uppdatera film */
// Steg 1. Hämta filmen som ska uppdateras.
// var x = await context.Movies.FindAsync(1);
// var movieToUpdate = await context.Movies.SingleOrDefaultAsync(c => c.Title == "21 Bridges");

// // Steg 2. uppdatera information i det funna objektet...
// movieToUpdate?.Rating = 8.1;

// bool hasChanges = context.ChangeTracker.HasChanges();

// if (context.ChangeTracker.HasChanges())
// {
//     await context.SaveChangesAsync();
// }

// WriteLine($"Has changes: {hasChanges}");

// // Steg 3. Spara ner till databasen!!!
// if (await context.SaveChangesAsync() > 0)
// {
//     var result = await context.Movies.SingleOrDefaultAsync(c => c.Title == "21 Bridges");
//     WriteLine($"Rating for 21 Bridges {result?.Rating}");
// }
// else
// {
//     WriteLine($"Det gick inte att uppdatera");
// }

/* Radera ett objekt(film) */
// Steg 1. Hämta in det som ska tas bort...
// var movieToRemove = await context.Movies.FindAsync(9);

// // Steg 2. Markera objektet för borttagning...
// context.Movies.Remove(movieToRemove!);

// bool hasChanges = context.ChangeTracker.HasChanges();
// WriteLine($"Has changes: {hasChanges}");

// // Steg 3. Spara förändringen till databasen...
// if (await context.SaveChangesAsync() > 0)
// {
//     WriteLine("Det gick bra");
// }
// else
// {
//     WriteLine("Gick inte så bra");
// }

// var newMovie = new Movie() { Title = "The Proposal", Director = "Anne Fletcher", ReleaseYear = 2009, Duration = 103, Rating = 6.8 };

// await context.Movies.AddAsync(newMovie);

// var movieToUpdate = await context.Movies.FirstOrDefaultAsync(c => c.Title == "21 Bridges");

// movieToUpdate?.Rating = 7.8;

// var movieToRemove = await context.Movies.FindAsync(1);

// if (movieToRemove is not null)
// {
//     context.Movies.Remove(movieToRemove);
// }

// var numberOfRowChanges = await context.SaveChangesAsync();

// WriteLine($"Antal rader som är förändrade: {numberOfRowChanges}");

// var mattD = new Actor() { FirstName = "Matt", LastName = "Damon" };
// var danielR = new Actor() { FirstName = "Daniel", LastName = "RadCliff" };
// var emmaW = new Actor() { FirstName = "Emma", LastName = "Watson" };
// var chadwickB = new Actor() { FirstName = "Chadwick", LastName = "Boseman" };
// var markW = new Actor() { FirstName = "Mark", LastName = "Wahlberg" };
// var siennaM = new Actor() { FirstName = "Sienna", LastName = "Miller" };

// var odyssey = await context.Movies.FirstOrDefaultAsync(c => c.Title == "The Odyssey");
// var harrypotter = await context.Movies.FirstOrDefaultAsync(c => c.Title == "Harry Potter och De Vises Sten");
// var bridges = await context.Movies.FirstOrDefaultAsync(c => c.Title.Contains("21"));
// var flightRisk = await context.Movies.FirstOrDefaultAsync(c => c.Title == "Flight Risk");

// odyssey?.Actors.Add(mattD);

// if (harrypotter is not null)
// {
//     harrypotter.Actors.Add(danielR);
//     harrypotter.Actors.Add(emmaW);
// }

// if (bridges is not null)
// {
//     bridges.Actors.Add(chadwickB);
//     bridges.Actors.Add(siennaM);
// }

// if (flightRisk is not null)
// {
//     flightRisk.Actors.Add(markW);
// }

// if (await context.SaveChangesAsync() > 0)
// {
//     WriteLine("Yeee det funkar");
// }
// else
// {
//     WriteLine("Satan i gatan det funkade inte!");
// }

// var movies = await context.Movies.ToListAsync();
// var movies = await context.Movies.Include(c => c.Actors).ToListAsync();

// foreach (var movie in movies)
// {
//     WriteLine($"Title: {movie.Title}");
//     foreach (var actor in movie.Actors)
//     {
//         WriteLine($"\tActor: {actor.FirstName} {actor.LastName}");
//     }
// }