using DebetCards.Models;
using Microsoft.EntityFrameworkCore;

namespace DebetCards.Data
{
    internal sealed class CardDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().ToTable("cards");
        }
    }
}
