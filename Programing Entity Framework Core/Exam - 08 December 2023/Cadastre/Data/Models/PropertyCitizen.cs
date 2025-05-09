﻿namespace Cadastre.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PropertyCitizen
    {
        [Required]
        [ForeignKey(nameof(Property))]
        public int PropertyId { get; set; }

        public Property Property { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Citizen))]
        public int CitizenId { get; set; }

        public Citizen Citizen { get; set; } = null!;

    }
}