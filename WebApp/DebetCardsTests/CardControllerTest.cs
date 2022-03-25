using AutoFixture;
using DebetCards.Controllers;
using DebetCards.Data;
using DebetCards.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DebetCardsTests
{
    public class CardControllerTest
    {
        private readonly CardController _controller;
        private readonly Mock<IRepository<Card>> _repositoryMock;
        private readonly Mock<IValidator<Card>> _validatorMock;

        public CardControllerTest()
        {
            _repositoryMock = new Mock<IRepository<Card>>();
            _validatorMock = new Mock<IValidator<Card>>();
            _controller = new CardController(_repositoryMock.Object, _validatorMock.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOk()
        {
            var fixture = new Fixture();
            var returnList = fixture.Create<System.Threading.Tasks.Task<IEnumerable<Card>>>();

            _repositoryMock.Setup(repository => repository.GetAll()).Returns(
                (System.Threading.Tasks.Task<IEnumerable<Card>>)returnList);

            var result = await _controller.Get();

            _repositoryMock.Verify(repository => repository.GetAll());
            _ = Assert.IsAssignableFrom<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
            Assert.IsAssignableFrom<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
        }
    }
}