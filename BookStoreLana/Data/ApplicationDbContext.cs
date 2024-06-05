using BookStoreLana.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreLana.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Auther> Authers { get; set; }
        public DbSet<BookCategory> BooksCategories { get; set; }
        public DbSet<Book> Books {  get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookCategory>().HasKey(e => new { 
            e.CategoryId,
            e.BookId
            });

            base.OnModelCreating(builder);
        }

		internal void saveChange()
		{
			throw new NotImplementedException();
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
