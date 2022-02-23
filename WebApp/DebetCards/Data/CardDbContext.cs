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
            modelBuilder.Entity<Card>().Property(u => u.Id).HasColumnName("card_id");
            modelBuilder.Entity<Card>().Property(u => u.Name).HasColumnName("name");
            modelBuilder.Entity<Card>().Property(u => u.CardNumber).HasColumnName("cardnumber");
            modelBuilder.Entity<Card>().Property(u => u.CVC).HasColumnName("cvc");
            modelBuilder.Entity<Card>().Property(u => u.ValidUntilMonth).HasColumnName("validuntilmonth");
            modelBuilder.Entity<Card>().Property(u => u.ValidUntilYear).HasColumnName("validuntilyear");
        }
    }
}
