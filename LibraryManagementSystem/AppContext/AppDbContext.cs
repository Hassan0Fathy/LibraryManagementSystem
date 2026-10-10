using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace LibraryManagementSystem.AppContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrowing> Borrowing { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Member> Member { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<Book>().Property(s => s.Price).HasPrecision(18, 2);

            modelBuilder.Entity<Book>().HasIndex(s => s.ISBN).IsUnique();

            modelBuilder.Entity<Book>().Property(s => s.IsAvailable).HasDefaultValue(true);

            modelBuilder.Entity<Member>().HasIndex(s => s.Email).IsUnique();

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books);

            modelBuilder.Entity<Borrowing>()
             .HasOne(b => b.Member)
             .WithMany(c => c.Borrowings);

            modelBuilder.Entity<Borrowing>()
            .HasOne(b => b.Book)
            .WithMany(c => c.Borrowings);

            // Seed Categories
            var categories = new[]
            {
                new Category { Id = 1, Name = "Fiction", Description = "Fictional stories and novels" },
                new Category { Id = 2, Name = "Non-Fiction", Description = "Real-world facts and information" },
                new Category { Id = 3, Name = "Science", Description = "Science and technology books" },
                new Category { Id = 4, Name = "History", Description = "Historical books and biographies" }
            };
            modelBuilder.Entity<Category>().HasData(categories);

            // Seed Books
            var books = new[]
            {
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "978-0743273565", Price = 12.99m, IsAvailable = true, CategoryId = 1 },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "978-0061120084", Price = 14.99m, IsAvailable = true, CategoryId = 1 },
                new Book { Id = 3, Title = "Sapiens", Author = "Yuval Noah Harari", ISBN = "978-0062316097", Price = 18.99m, IsAvailable = true, CategoryId = 2 },
                new Book { Id = 4, Title = "A Brief History of Time", Author = "Stephen Hawking", ISBN = "978-0553380163", Price = 16.99m, IsAvailable = false, CategoryId = 3 },
                new Book { Id = 5, Title = "The Art of War", Author = "Sun Tzu", ISBN = "978-0486427072", Price = 9.99m, IsAvailable = true, CategoryId = 4 }
            };
            modelBuilder.Entity<Book>().HasData(books);

            // Seed Members
            var members = new[]
            {
                new Member { Id = 1, FullName = "John Smith", Email = "john.smith@email.com", Phone = "+1-555-0101" },
                new Member { Id = 2, FullName = "Jane Doe", Email = "jane.doe@email.com", Phone = "+1-555-0102" },
                new Member { Id = 3, FullName = "Robert Johnson", Email = "robert.johnson@email.com", Phone = "+1-555-0103" },
                new Member { Id = 4, FullName = "Emily Williams", Email = "emily.williams@email.com", Phone = "+1-555-0104" }
            };
            modelBuilder.Entity<Member>().HasData(members);

            // Seed Borrowings
            var borrowings = new[]
            {
                new Borrowing { Id = 1, BorrowDate = new DateTime(2025, 10, 01), ReturnDate = new DateTime(2025, 10, 15), MemberId = 1, BookId = 1 },
                new Borrowing { Id = 2, BorrowDate = new DateTime(2025, 10, 02), ReturnDate = null, MemberId = 2, BookId = 4 },
                new Borrowing { Id = 3, BorrowDate = new DateTime(2025, 10, 05), ReturnDate = null, MemberId = 3, BookId = 3 },
                new Borrowing { Id = 4, BorrowDate = new DateTime(2025, 09, 20), ReturnDate = new DateTime(2025, 10, 03), MemberId = 4, BookId = 2 }
            };
            modelBuilder.Entity<Borrowing>().HasData(borrowings);

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
