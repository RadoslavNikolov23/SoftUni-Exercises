﻿namespace MusicHub.Data.Models
{
    public class Writer
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Pseudonym { get; set; }

        public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();

    }
}
