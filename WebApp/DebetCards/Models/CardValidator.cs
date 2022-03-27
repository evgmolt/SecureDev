using FluentValidation;

namespace DebetCards.Models
{
    public class CardValidator : AbstractValidator<Card>
    {
        private const int _cardNumberLenght = 16;
        private const int _cvcLength = 3;
        public CardValidator()
        {
            RuleFor(x => x.CardNumber).Must(c => c.ToString().PadLeft(16, '0').Length == _cardNumberLenght);
            RuleFor(x => x.Name).Must(c => c.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
            RuleFor(x => x.CVC).Must(c => c.ToString().PadLeft(3, '0').Length == _cvcLength);
            RuleFor(x => x.ValidUntilMonth).GreaterThan(0).LessThanOrEqualTo(12);
            RuleFor(x => x.ValidUntilYear).GreaterThanOrEqualTo(DateTime.Today.Year - 2000);
        }
    }
}
