namespace CinemaApp.Data.Utilities
{
    using CinemaApp.Data.DTOs;
    using CinemaApp.Data.Models;
    using CinemaApp.Data.Utilities.Contracts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using System.Globalization;
    using System.Text.Json;

    public class DataProcessor
    {
        private readonly IEntityValidator entityValidator;
        private readonly ILogger<DataProcessor> logger;

        public DataProcessor(IEntityValidator entityValidator, ILogger<DataProcessor> logger)
        {
            this.entityValidator = entityValidator;
            this.logger = logger;
        }

        public async Task ImportMoviesFromJson(CinemaDbContext dbContext)
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

                    if (!await this.entityValidator.IsValid(movieDTO))
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

        public async Task ImportCinemaMoviesFromJson(CinemaDbContext dbContext)
        {
            string cinemaMoviesStr = await GetFileString("cinemasMovies.json");
            var cinemaMoviesDTOs = JsonSerializer.Deserialize<List<CinemaMoviesDTO>>(cinemaMoviesStr);

            if (cinemaMoviesDTOs != null)
            {
                ICollection<CinemaMovie> validCinemaMovies = new List<CinemaMovie>();

                foreach (var cinemaMovieDTO in cinemaMoviesDTOs)
                {
                    if (!await this.entityValidator.IsValid(cinemaMovieDTO))
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

        public async Task ImportTicketsFromXml(CinemaDbContext dbContext)
        {
            string filePath =Path.Combine(AppContext.BaseDirectory, "Files", "tickets.xml");
            string ticketsStr = await File.ReadAllTextAsync(filePath);

            IXmlHelper xmlHelper = new XmlHelper();
            string rootName = "Tickets";

            TicketDto[]? ticketDtos = xmlHelper
                    .Deserialize<TicketDto[]>(ticketsStr, rootName);

            if (ticketDtos != null && ticketDtos.Length > 0)
            {
                ICollection<Ticket> validTickets = new List<Ticket>();

                foreach (TicketDto ticketDto in ticketDtos)
                {
                    if (!await this.entityValidator.IsValid(ticketDto))
                        continue;

                    bool isPriceValid = decimal
                                            .TryParse(ticketDto.Price, 
                                            NumberStyles.Any,
                                            CultureInfo.InvariantCulture, out decimal ticketPrice);
                    bool isMovieIdValid = Guid
                                            .TryParse(ticketDto.MovieId, out Guid ticketMovieId);
                    bool isCinemaIdValid = Guid
                                            .TryParse(ticketDto.CinemaId, out Guid ticketCinemaId);
                    bool isUserIdValid = Guid
                                            .TryParse(ticketDto.UserId, out Guid ticketUserId);
                   
                    if (!isPriceValid || !isMovieIdValid 
                        || !isCinemaIdValid || !isUserIdValid)
                       continue;


                    Cinema? ticketCinema = await dbContext
                                                         .Cinemas
                                                          .SingleOrDefaultAsync(c => c.Id == ticketCinemaId);

                    Movie? ticketMovie = await dbContext
                                                         .Movies
                                                          .SingleOrDefaultAsync(m => m.Id == ticketMovieId);
                   
                    ApplicationUser? ticketUser = await dbContext
                                                            .Users
                                                            .SingleOrDefaultAsync(u => u.Id == ticketUserId);
                    
                    if (ticketCinema == null || ticketMovie == null || ticketUser == null)
                    {
                        continue;
                    }


                    Ticket newTicket = new Ticket()
                    {
                        Price = ticketPrice,
                        CinemaId = ticketCinemaId,
                        MovieId = ticketMovieId,
                        ApplicationUserId = ticketUserId
                    };
                    validTickets.Add(newTicket);
                }

                await dbContext.Tickets.AddRangeAsync(validTickets);
                await dbContext.SaveChangesAsync();
            }

        }

        private async Task<string> GetFileString(string fileName)
        {
            string projectDirectory = Path.Combine(AppContext.BaseDirectory, "Files", fileName);
            string fileStr = await File.ReadAllTextAsync(projectDirectory);
            return fileStr;
        }



    }
}
