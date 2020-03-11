using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public bool? IsEnabled { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
