using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Stock)         // A comment has 1 stock
                .WithMany(s => s.Comments)    // A stock has many comments
                .HasForeignKey(c => c.StockId) // FK is StockId
                .OnDelete(DeleteBehavior.Cascade); // if stock deleted → comments deleted
        }
    }
}
