using FluentValidation;

namespace DebetCards.Models
{
    public class CardValidator : AbstractValidator<Card>
    {
        private const int _cardNumberLenght = 16;
        private const int _cvcLength = 3;
        public CardValidator()
        {
            RuleFor(x => x.CardNumber.ToString().Length == _cardNumberLenght);
            RuleFor(x => x.Name.All(c => char.IsLetter(c) || c == ' '));
            RuleFor(x => x.CVC.ToString().Length == _cvcLength);
            RuleFor(x => x.ValidUntilMonth).GreaterThan(0).LessThanOrEqualTo(12);
            RuleFor(x => x.ValidUntilYear).GreaterThanOrEqualTo(DateTime.Today.Year - 2000);
        }
    }
}
