using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Issue
    {
        public int Id { get; set; }
        public DateTime? IssueDate { get; set; }
        public int? BookId { get; set; }
        public int? CustomerId { get; set; }
        public int? NoOfDays { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }

        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
