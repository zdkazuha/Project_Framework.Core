using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Entities
{
    public class SalesArchive
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public DateTime DateOfSale { get; set; }

        [Required]
        public int SellingPrice { get; set; }

        // Navigation property
        public User User { get; set; }
        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
