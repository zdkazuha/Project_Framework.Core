using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Entities
{
    public class BookPostponed
    {
        public int Id { get; set; }
        public int BookId { get; set; }  
        public int UserId { get; set; } 

        // Navigation property
        public Book Book { get; set; }
        public User User { get; set; }
    }
}
