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

        public async Task Add(Card card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            Card? card = _context.Cards.FirstOrDefault(i => i.Id == id);
            if (card is null) return;
            _context.Cards.Remove(card);
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

        public async Task Update(Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
        }
    }
}
