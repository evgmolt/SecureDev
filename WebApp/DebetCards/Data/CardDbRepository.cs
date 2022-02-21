using DebetCards.Models;
using Npgsql;

namespace DebetCards.Data
{
    public class CardDbRepository : IRepository<Card>
    {
        private readonly string _connectionString;
        public CardDbRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Postgres");
        }
        public async Task Add(Card card)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            string commandText = $"INSERT INTO cards (card_id, Name, cardnumber, cvc, validuntilmonth, validuntilyear) VALUES (@card_id, @name, @cardnumber, @cvc, @validuntilmonth, @validuntilyear)";
            using (var cmd = new NpgsqlCommand(commandText, conn))
            {
                cmd.Parameters.AddWithValue("card_id", card.Id);
                cmd.Parameters.AddWithValue("name", card.Name);
                cmd.Parameters.AddWithValue("cardnumber", card.CardNumber);
                cmd.Parameters.AddWithValue("cvc", card.CVC);
                cmd.Parameters.AddWithValue("validuntilmonth", card.ValidUntilMonth);
                cmd.Parameters.AddWithValue("validuntilyear", card.ValidUntilYear);
                cmd.ExecuteNonQuery();
            }
        }

        public async Task DeleteById(int id)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            string commandText = $"DELETE FROM cards WHERE card_id = {id}";
            using (var cmd = new NpgsqlCommand(commandText, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public async Task<IEnumerable<Card>> GetAll()
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            await conn.OpenAsync();
            List<Card> result = new();
            await using (var cmd = new NpgsqlCommand("SELECT * FROM cards", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    Card card = new Card();
                    card.Id = reader.GetInt32(0);
                    card.Name = reader.GetString(1);
                    card.CardNumber = reader.GetInt64(2);
                    card.CVC = reader.GetInt32(3);
                    card.ValidUntilMonth = reader.GetInt32(4);
                    card.ValidUntilYear = reader.GetInt32(5);
                    result.Add(card);
                }
            };
            return result;
        }

        public async Task<Card> GetById(int id)
        {
            await using var conn = new NpgsqlConnection(_connectionString);
            Card card = new Card();
            await conn.OpenAsync();
            await using (var cmd = new NpgsqlCommand($"SELECT * FROM cards WHERE card_id = {id}", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
            {
                await reader.ReadAsync();
                card.Id = reader.GetInt32(0);
                card.Name = reader.GetString(1);
                card.CardNumber = reader.GetInt64(2);
                card.CVC = reader.GetInt32(3);
                card.ValidUntilMonth = reader.GetInt32(4);
                card.ValidUntilYear = reader.GetInt32(5);
            };
            return card;
        }

        public Task Update(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
