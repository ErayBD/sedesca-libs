using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;

namespace ServiceLayer.Context {
	public class ApplicationDbContext : IdentityDbContext {
		
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }

		public DbSet<Student> Students { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<StudentBook> StudentBooks { get; set; }
		public DbSet<Author> Author { get; set; }
		public DbSet<Genre> Genre { get; set; }
		public DbSet<MyBooks> MyBooks { get; set; }
		public DbSet<ReturnBook> ReturnBook { get; set; } = default!;

        

        
    }
}
