using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Entities
{
    public class Book
    {
        public Book()
        {
            SalesArchives = new List<SalesArchive>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required,]
        public string Title { get; set; }
        [MaxLength(50), Required,]
        public string Genre { get; set; }
        [MaxLength(50), Required,]
        public string PublishingHouseName { get; set; }
        [Required]
        public int NumberOfPages { get; set; }
        [Required]
        public int YearOfPublication { get; set; }
        [Required]
        public int SellingPrice { get; set; }
        [Required]
        public int CostPrice { get; set; }
        [Required]
        public bool IsItASequel { get; set; } = false;
        public int AuthorId { get; set; }
        public int ?TrilogiesId { get; set; }
        //public int SalesArchivesId { get; set; }

        // Navigation property

        public Trilogies ?Trilogies { get; set; }
        public Author Author { get; set; }
        public ICollection<SalesArchive> ?SalesArchives { get; set; }
        public ICollection<BookPostponed> ?BookPostponed { get; set; }
    }
}
