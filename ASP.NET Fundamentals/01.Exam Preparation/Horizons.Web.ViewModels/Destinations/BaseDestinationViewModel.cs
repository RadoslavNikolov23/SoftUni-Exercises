﻿namespace Horizons.Web.ViewModels.Destinations
{
    using System.ComponentModel.DataAnnotations;
    using static Horizons.GCommon.ValidationConstants;

    public abstract class BaseDestinationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        //Terrain Name is used here
        public string Terrain { get; set; } = null!;

        public bool IsPublisher { get; set; }

        public bool IsFavorite { get; set; }
    }
}
