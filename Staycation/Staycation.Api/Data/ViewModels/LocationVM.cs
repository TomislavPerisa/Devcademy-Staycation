﻿using System.ComponentModel.DataAnnotations;

namespace Staycation.Api.Data.ViewModels
{
    public class LocationVM
    {
        [MaxLength(800)]
        public string? ImageUrl { get; set; }

        [MaxLength(50)]
        public string? PostalCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}