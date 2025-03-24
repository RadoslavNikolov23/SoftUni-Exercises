namespace CinemaApp.Data.Utilities
{
    using CinemaApp.Data.DTOs;
    using CinemaApp.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json;

    public static class DataProcessor
    {
        public static async Task ImportMoviesFromJson(CinemaDbContext dbContext)
        {
            string moviesStr = await GetFileString("movies.json");
            var moviesDTOs = JsonSerializer.Deserialize<List<MoviesDTO>>(moviesStr);

            if (moviesDTOs != null)
            {
                ICollection<Movie> validMovies = new List<Movie>();
                IList<string> moviesTitles = await dbContext.Movies.Select(m => m.Title).ToListAsync(); //Gets the all the movies titles from the database

                foreach (var movieDTO in moviesDTOs)
                {
                    //Checks if the movie is already in the database, if the movie is already in the database it will not be added.
                    if (moviesTitles.Contains(movieDTO.Title)) 
                        continue;

                    if (!await IsValid(movieDTO))
                        continue;

                    Movie movie = new Movie
                    {
                        Title = movieDTO.Title,
                        Genre = movieDTO.Genre,
                        ReleaseDate = movieDTO.ReleaseDate,
                        Director = movieDTO.Director,
                        Duration = movieDTO.Duration,
                        Description = movieDTO.Description,
                        ImageUrl = movieDTO.ImageUrl
                    };

                    validMovies.Add(movie);
                }
                await dbContext.Movies.AddRangeAsync(validMovies);
                await dbContext.SaveChangesAsync();
            }

        }

        public static async Task ImportCinemaMoviesFromJson(CinemaDbContext dbContext)
        {
            string cinemaMoviesStr = await GetFileString("cinemasMovies.json");
            var cinemaMoviesDTOs = JsonSerializer.Deserialize<List<CinemaMoviesDTO>>(cinemaMoviesStr);

            if (cinemaMoviesDTOs != null)
            {
                ICollection<CinemaMovie> validCinemaMovies = new List<CinemaMovie>();



                foreach (var cinemaMovieDTO in cinemaMoviesDTOs)
                {
                    if (!await IsValid(cinemaMovieDTO))
                        continue;

                    Movie movie = dbContext.Movies.FirstOrDefault(m => m.Title == cinemaMovieDTO.Movie)!;

                    var cinemaName = cinemaMovieDTO.Cinema
                                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(cn => cn.Trim())
                                    .ToArray();

                    //Gets the cinema from the database
                    Cinema cinema = null!;
                    if (cinemaName.Length > 1)
                    {
                        cinema = dbContext.Cinemas
                            .Where(c => c.Name == cinemaName[0])
                            .FirstOrDefault(c => c.Location == cinemaName[1])!;
                    }
                    else
                    {
                        cinema = dbContext.Cinemas
                            .FirstOrDefault(c => c.Name == cinemaMovieDTO.Cinema)!;
                    }


                    if (movie == null || cinema == null)
                        continue;

                    //Gets all the movies titles from the database in the specific cinema, if the movie is already in the cinema it will not be added.
                    IList<string> cinemaMoviesTitles = await dbContext.CinemaMovies
                                .Where(cm => cinemaName.Length > 1 
                                ? cm.Cinema.Name == cinemaName[0] 
                                    && cm.Cinema.Location == cinemaName[1] 
                                : cm.Cinema.Name == cinemaName[0])    
                                .Select(cm => cm.Movie.Title)
                                .ToListAsync();

                    if (cinemaMoviesTitles.Any(cm => cm == movie.Title))
                        continue;

                    CinemaMovie cinemaMovie = new CinemaMovie
                    {
                        Movie = movie,
                        Cinema = cinema,
                        AvailableTickets = cinemaMovieDTO.AvailableTickets,
                        IsDeleted = cinemaMovieDTO.IsDeleted,
                        Showtimes = cinemaMovieDTO.Showtimes
                    };

                    validCinemaMovies.Add(cinemaMovie);
                }

                await dbContext.CinemaMovies.AddRangeAsync(validCinemaMovies);
                await dbContext.SaveChangesAsync();
            }
        }

        public static async Task ImportTicketsFromXml(CinemaDbContext dbContext)
        {
            throw new NotImplementedException();
        }

        private static async Task<string> GetFileString(string fileName)
        {
            string projectDirectory = Path.Combine(AppContext.BaseDirectory, "Files", fileName);
            string fileStr = await File.ReadAllTextAsync(projectDirectory);
            return fileStr;
        }

        private static Task<bool> IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Task.FromResult(Validator.TryValidateObject(dto, validationContext, validationResult, true));
        }

    }
}
