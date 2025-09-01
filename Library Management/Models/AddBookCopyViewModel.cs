using System;
using System.ComponentModel.DataAnnotations;

namespace Library_Management.Models
{
    public class AddBookCopyViewModel
    {
        [Required]
        public Guid BookId { get; set; }
        [Required]
        public string? CoverImageUrl { get; set; }
        [Required]
        public string? Condition { get; set; }
        [Required]
        public string? Source { get; set; }
    }
}
