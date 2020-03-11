using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class dimple6002_LibraryManagementSystemContext : DbContext
    {
        public dimple6002_LibraryManagementSystemContext()
        {
        }

        public dimple6002_LibraryManagementSystemContext(DbContextOptions<dimple6002_LibraryManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-NI9FNBTG\\SQLEXPRESS02;Database=dimple6002_LibraryManagementSystem;Trusted_Connection=True;User=sa;Password=sa123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("AUTHOR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(1);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("BOOK");

                entity.HasIndex(e => e.BookName)
                    .HasName("UQ__BOOK__DAF8BF78CCEAB3E1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId).HasColumnName("AUTHOR_ID");

                entity.Property(e => e.BookDescription)
                    .HasColumnName("BOOK_DESCRIPTION")
                    .HasMaxLength(255);

                entity.Property(e => e.BookName)
                    .HasColumnName("BOOK_NAME")
                    .HasMaxLength(255);

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.InStock).HasDefaultValueSql("((1))");

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PublishYear).HasColumnName("PUBLISH_YEAR");

                entity.Property(e => e.PublisherId).HasColumnName("PUBLISHER_ID");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__BOOK__AUTHOR_ID__5165187F");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__BOOK__CATEGORY_I__4F7CD00D");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK__BOOK__PUBLISHER___5070F446");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__CATEGORY__D9C1FA00F020BCC0")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Abbrivation)
                    .HasColumnName("ABBRIVATION")
                    .HasMaxLength(10);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255);

                entity.Property(e => e.City)
                    .HasColumnName("CITY")
                    .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .HasColumnName("COUNTRY")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(1);

                entity.Property(e => e.LastName)
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.ToTable("ISSUE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BookId).HasColumnName("BOOK_ID");

                entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.IssueDate)
                    .HasColumnName("ISSUE_DATE")
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NoOfDays).HasColumnName("NO_OF_DAYS");

                entity.Property(e => e.Rate)
                    .HasColumnName("RATE")
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__ISSUE__BOOK_ID__5812160E");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__ISSUE__CUSTOMER___59063A47");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("PUBLISHER");

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__PUBLISHE__D9C1FA0022904AFB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("CONTACT_PERSON")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.IsEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.Mobileno)
                    .HasColumnName("MOBILENO")
                    .HasMaxLength(20);

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(50);
            });
        }
    }
}
