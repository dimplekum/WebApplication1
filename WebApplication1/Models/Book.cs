using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Book
    {
        public Book()
        {
            Issue = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public int? CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public int? AuthorId { get; set; }
        public decimal? Price { get; set; }
        public int? PublishYear { get; set; }
        public bool? InStock { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Issue> Issue { get; set; }
    }
}
