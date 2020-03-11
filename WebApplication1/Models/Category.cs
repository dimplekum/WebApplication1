using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Category
    {
        public Category()
        {
            Book = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbrivation { get; set; }
        public bool? IsEnabled { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
