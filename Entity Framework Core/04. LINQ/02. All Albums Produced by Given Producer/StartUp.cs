namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            const int producerdId = 9;
            string getAlbumInfo = ExportAlbumsInfo(context, producerdId);
            Console.WriteLine(getAlbumInfo);

            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums!
                .Where(a => a.ProducerId.HasValue &&
                            a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer!.Name,
                    AlbumSongs = a.Songs.Select(s => new
                                {
                                    SongName = s.Name,
                                    Price = s.Price.ToString("F2"),
                                    SongWriter = s.Writer.Name,

                                })
                                .OrderByDescending(s => s.SongName)
                                .ThenBy(s => s.SongWriter)
                                .ToArray(),
                    TotalPrice = a.Price
                })
                .ToArray();

            albums = albums
                .OrderByDescending(a => a.TotalPrice)
                .ToArray();
            
            foreach(var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}")
                  .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                  .AppendLine($"-ProducerName: {album.ProducerName}")
                  .AppendLine($"-Songs:");

                int index = 1;
                foreach(var song in album.AlbumSongs)
                {
                     sb.AppendLine($"---#{index++}")
                       .AppendLine($"---SongName: {song.SongName}")
                       .AppendLine($"---Price: {song.Price}")
                       .AppendLine($"---Writer: {song.SongWriter}");
                }

                sb.AppendLine($"-AlbumPrice: {album.TotalPrice.ToString("F2")}");
            }

            return sb.ToString().Trim();
            
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
