using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new List<Book>();
            SalesArchives = new List<SalesArchive>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string FirstName { get; set; }
        [MaxLength(50), Required]
        public string LastName { get; set; }

        // Navigation property

        public ICollection<Book> Books { get; set; }
        public ICollection<SalesArchive> SalesArchives { get; set; }
    }
}
