using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zajecia_ASPNET.Models
{
    public class BookModel
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Column("Year")]
        [Required]
        public int YearOfPublication { get; set; }

        [RegularExpression(@"^([0-9]{3}-)?([0-9]{2}-(([0-9]{2}-[0-9]{5})|([0-9]{3}-[0-9]{4})|([0-9]{4}-[0-9]{3})|([0-9]{5}-[0-9]{2})|([0-9]{6}-[0-9]{1}))-[0-9]{1})$")]
        public string? ISBN { get; set; }
        
    }
}
