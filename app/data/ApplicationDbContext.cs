using Microsoft.EntityFrameworkCore;
namespace app
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DbSet<Author> Authors { set; get; }

        public DbSet<Book> Books { set; get; }

        public DbSet<SalesInvoice> SalesInvoices { set; get; }

        
    }
}
