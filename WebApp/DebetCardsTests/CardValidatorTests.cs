using DebetCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation.TestHelper;
using Xunit;

namespace DebetCardsTests
{
    public class CardValidatorTests
    {
        private CardValidator _validator;
        private CardBuilder _cardBuilder;

        public CardValidatorTests()
        {
            _validator = new CardValidator();
            _cardBuilder = new CardBuilder();
        }

        [Fact]
        public void Should_Not_Errors()
        {
            Card card = _cardBuilder.GetRandomCard();
            var result = _validator.TestValidate(card);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Should_Name_Errors()
        {
            Card card = _cardBuilder.GetRandomCard();
            card.Name = "hsjgfdhjsa1111";
            var result = _validator.TestValidate(card);
            result.ShouldHaveValidationErrorFor(card => card.Name);
        }

        [Fact]
        public void Should_CVC_Errors()
        {
            Card card = _cardBuilder.GetRandomCard();
            card.CVC = 1111;
            var result = _validator.TestValidate(card);
            result.ShouldHaveValidationErrorFor(card => card.CVC);
        }
        [Fact]
        public void Should_Month_Errors()
        {
            Card card = _cardBuilder.GetRandomCard();
            card.ValidUntilMonth = 100;
            var result = _validator.TestValidate(card);
            result.ShouldHaveValidationErrorFor(card => card.ValidUntilMonth);
        }

        [Fact]
        public void Should_Year_Errors()
        {
            Card card = _cardBuilder.GetRandomCard();
            card.ValidUntilYear = 18;
            var result = _validator.TestValidate(card);
            result.ShouldHaveValidationErrorFor(card => card.ValidUntilYear);
        }
    }
}
