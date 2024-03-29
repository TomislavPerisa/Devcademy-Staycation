﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Staycation.Api.Data.Models
{
    public class Accommodation
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string? Subtitle { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }
        
        [Range(1,5)]
        [Required]
        public int Categorization { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int PersonCount { get; set; }

        [MaxLength(800)]
        public string? ImageTitle { get; set; }

        public byte[]? ImageData { get; set; }

        [Required]
        public bool? FreeCancelation { get; set; }
        
        [Required]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        //Navigation properties
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public List<Reservation> Reservations { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Accommodation)) return false;
            return this.Id == ((Accommodation)obj).Id &&
                this.Title == ((Accommodation)obj).Title &&
                this.Subtitle == ((Accommodation)obj).Subtitle &&
                this.Description == ((Accommodation)obj).Description &&
                this.Type == ((Accommodation)obj).Type &&
                this.Categorization == ((Accommodation)obj).Categorization &&
                this.PersonCount == ((Accommodation)obj).PersonCount &&
                this.ImageTitle == ((Accommodation)obj).ImageTitle &&
                this.FreeCancelation == ((Accommodation)obj).FreeCancelation &&
                this.Price == ((Accommodation)obj).Price;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^
                Title.GetHashCode() ^
                Subtitle.GetHashCode() ^
                Description.GetHashCode() ^
                Type.GetHashCode() ^
                Categorization.GetHashCode() ^
                PersonCount.GetHashCode() ^
                ImageTitle.GetHashCode() ^
                FreeCancelation.GetHashCode() ^
                Price.GetHashCode();
        }

        public override string ToString()
        {
            return "Id:" + Id.ToString() + ',' +
                "Title:" + Title.ToString() + ',' +
                "Subtitle:" + Subtitle.ToString() + ',' +
                "Description:" + Description.ToString() + ',' +
                "Type:" + Type.ToString() + ',' +
                "Categorization:" + Categorization.ToString() + ',' +
                "PersonCount:" + PersonCount.ToString() + ',' +
                "ImageUrl:" + ImageTitle.ToString() + ',' +
                "FreeCancelation:" + FreeCancelation.ToString() + ',' +
                "Price:" + Price.ToString() + '.';
        }
    }
}