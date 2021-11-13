using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRaterApi.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}