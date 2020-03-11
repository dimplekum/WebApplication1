using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }
        public string ContactPerson { get; set; }
        public bool? IsEnabled { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
