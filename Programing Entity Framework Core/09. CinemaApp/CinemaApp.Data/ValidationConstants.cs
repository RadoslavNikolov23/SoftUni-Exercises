namespace CinemaApp.Data
{
    public class ValidationConstants
    {
        public static class ValidationMovie
        {
            public const int maxLengthMovieTitle = 200;

            public const int maxLengthGenre = 60;

            public const int maxLengthDirectorName = 150;

            public const int maxLengthDescriptionOfMovie = 1024;

            public const int maxLengthImageUrlForMovie = 260;

        }

        public static class ValidationCinema
        {
            public const int maxLengthCinemaName = 150;

            public const int maxLengthNameOfTheLocationOfCinema = 150;

        }

        public static class ValidationCinemaMovie
        {
            public const int maxLengthShowtimesOfTheMoviesInTheCinema = 5;

        }

    }
}
