using DebetCards.Models;
using Microsoft.EntityFrameworkCore;

namespace DebetCards.Data
{
    internal sealed class CardEFRepository : IRepository<Card>
    {
        private readonly CardDbContext _context;
        public CardEFRepository(CardDbContext context)
        {
            _context = context;
        }

        public async Task Add(Card item)
        {
            await _context.Cards.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Card item)
        {
            _context.Cards.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Card>> GetAll()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card> GetById(int id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public async Task Update(Card item)
        {
            _context.Cards.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
