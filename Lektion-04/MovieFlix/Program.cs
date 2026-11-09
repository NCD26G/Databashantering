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
var movies = context.Movies.ToList().Count;
WriteLine($"Number of movies in the database: {movies}");

var movieCount = context.Movies.ToList().Count;
WriteLine($"Number of movies in the database: {movieCount}");

// context.Movies.Add(movie1);
// context.Movies.Add(movie2);

// // Jag är klar spara till databasen...
// await context.SaveChangesAsync();

// movies = context.Movies.ToList().Count;
// WriteLine($"Number of movies in the database: {movies}");