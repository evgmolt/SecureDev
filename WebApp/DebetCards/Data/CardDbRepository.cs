using DebetCards.Models;
using Npgsql;

namespace DebetCards.Data
{
    public class CardDbRepository : IRepository<Card>
    {
        public CardDbRepository()
        {
        }
        public Task Add(Card item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Card item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Card>> GetAll()
        {
            await using var conn = new NpgsqlConnection("User Id=postgres;Password=1111;Server=localhost;Port=5432;Database=cards");
            await conn.OpenAsync();
            List<Card> result = new();
            await using (var cmd = new NpgsqlCommand("SELECT * FROM cards", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    string s = reader.GetString(0);
                    result.Add(new Card());
                }
            };
            return result;
        }

        public Task<Card> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Card item)
        {
            throw new NotImplementedException();
        }
    }
}
