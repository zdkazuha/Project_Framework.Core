using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbController.Entities
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            SalesArchives = new List<SalesArchive>();
            BookPostponeds = new List<BookPostponed>();
        }
        [Key]
        public int Id { get; set; }
        [MaxLength(50),Required]
        public string UserName { get; set; }
        [MaxLength(50), Required]
        public string Password { get; set; }
        [Required]
        public int Money { get; set; }

        
        // Navigation property
        
        public ICollection<SalesArchive> SalesArchives { get; set; }
        public ICollection<BookPostponed> BookPostponeds { get; set; }
    }
}
