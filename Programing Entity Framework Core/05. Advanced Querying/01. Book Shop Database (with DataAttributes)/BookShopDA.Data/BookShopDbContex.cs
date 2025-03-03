namespace BookShopDA.Data
{
    using BookShopDA.Model;
    using Microsoft.EntityFrameworkCore;
    public class BookShopDbContex : DbContext
    {
        public BookShopDbContex(DbContextOptions options) : base(options)
        {
        }

        public BookShopDbContex()
        {
        }

        public DbSet<Author>? Authors { get; set; }
        public DbSet<Book>? Books { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<BookCategory>? BookCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if(!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(ConnectionStringConfiguretions.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
        }
    }
}
