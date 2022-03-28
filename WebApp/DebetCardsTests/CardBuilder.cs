using DebetCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebetCardsTests
{
    internal class CardBuilder
    {
        private readonly Random _random;
        private readonly int _year;
        public CardBuilder()
        {
            _random = new Random();
            _year = DateTime.Today.Year - 2000;
        }
        public Card GetRandomCard()
        {
            return new()
            {
                Name = "Name Surname",
                CardNumber = _random.NextInt64(9999999999999999),
                CVC = _random.Next(999),
                ValidUntilMonth = _random.Next(1, 12),
                ValidUntilYear = _random.Next(_year, _year + 10)
            };
        }
    }
}
