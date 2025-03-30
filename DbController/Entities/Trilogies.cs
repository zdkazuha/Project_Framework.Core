    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace DbController.Entities
    {
        public class Trilogies
        {
            public Trilogies()
            {
                Books = new List<Book>();
            }

            [Key]
            public int Id { get; set; }
            [MaxLength(50), Required,]
            public string NameTrilogie { get; set; }
            public ICollection<Book> Books { get; set; }
        }
    }
