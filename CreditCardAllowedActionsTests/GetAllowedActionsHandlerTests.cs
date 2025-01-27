using CreditCardAllowedActions.Application.Features.CreditCard.GetAllowedActions.Handlers;
using CreditCardAllowedActions.Application.Features.CreditCard.GetAllowedActions.Queries;
using CreditCardAllowedActions.Domain.Enums;
using CreditCardAllowedActions.Domain.ValueObjects;
using CreditCardAllowedActions.Infrastructure.Persistence.Repositories.Interfaces;
using Moq;

namespace CreditCardAllowedActionsTests
{
    public class GetAllowedActionsHandlerTests
    {
        private Mock<ICardServiceRepository> _cardServiceRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _cardServiceRepositoryMock = new Mock<ICardServiceRepository>();
        }

        [Test]
        [TestCase(CardType.Prepaid, CardStatus.Ordered, true, new[] { "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Prepaid, CardStatus.Ordered, false, new[] { "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Prepaid, CardStatus.Inactive, true, new[] { "ACTION2", "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Prepaid, CardStatus.Inactive, false, new[] { "ACTION2", "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Prepaid, CardStatus.Active, true, new[] { "ACTION1", "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Prepaid, CardStatus.Active, false, new[] { "ACTION1", "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Prepaid, CardStatus.Restricted, true, new[] { "ACTION3", "ACTION4", "ACTION9" })]
        [TestCase(CardType.Prepaid, CardStatus.Restricted, false, new[] { "ACTION3", "ACTION4", "ACTION9" })]
        [TestCase(CardType.Prepaid, CardStatus.Blocked, true, new[] { "ACTION3", "ACTION4", "ACTION6", "ACTION7", "ACTION8", "ACTION9" })]
        [TestCase(CardType.Prepaid, CardStatus.Blocked, false, new[] { "ACTION3", "ACTION4", "ACTION8", "ACTION9" })]
        [TestCase(CardType.Prepaid, CardStatus.Expired, true, new[] { "ACTION3", "ACTION4", "ACTION9" })]
        [TestCase(CardType.Prepaid, CardStatus.Expired, false, new[] { "ACTION3", "ACTION4", "ACTION9" })]
        [TestCase(CardType.Prepaid, CardStatus.Closed, true, new[] { "ACTION3", "ACTION4", "ACTION9" })]
        [TestCase(CardType.Prepaid, CardStatus.Closed, false, new[] { "ACTION3", "ACTION4", "ACTION9" })]

        [TestCase(CardType.Debit, CardStatus.Ordered, true, new[] { "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Debit, CardStatus.Ordered, false, new[] { "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Debit, CardStatus.Inactive, true, new[] { "ACTION2", "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Debit, CardStatus.Inactive, false, new[] { "ACTION2", "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Debit, CardStatus.Active, true, new[] { "ACTION1", "ACTION3", "ACTION4", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Debit, CardStatus.Active, false, new[] { "ACTION1", "ACTION3", "ACTION4", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Debit, CardStatus.Restricted, true, new[] { "ACTION3", "ACTION4", "ACTION9" })]
        [TestCase(CardType.Debit, CardStatus.Restricted, false, new[] { "ACTION3", "ACTION4", "ACTION9" })]
        [TestCase(CardType.Debit, CardStatus.Blocked, true, new[] { "ACTION3", "ACTION4", "ACTION6", "ACTION7", "ACTION8", "ACTION9" })]
        [TestCase(CardType.Debit, CardStatus.Blocked, false, new[] { "ACTION3", "ACTION4", "ACTION8", "ACTION9" })]
        [TestCase(CardType.Debit, CardStatus.Expired, true, new[] { "ACTION3", "ACTION4", "ACTION9" })]
        [TestCase(CardType.Debit, CardStatus.Expired, false, new[] { "ACTION3", "ACTION4", "ACTION9" })]
        [TestCase(CardType.Debit, CardStatus.Closed, true, new[] { "ACTION3", "ACTION4", "ACTION9" })]
        [TestCase(CardType.Debit, CardStatus.Closed, false, new[] { "ACTION3", "ACTION4", "ACTION9" })]

        [TestCase(CardType.Credit, CardStatus.Ordered, true, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Credit, CardStatus.Ordered, false, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Credit, CardStatus.Inactive, true, new[] { "ACTION2", "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Credit, CardStatus.Inactive, false, new[] { "ACTION2", "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Credit, CardStatus.Active, true, new[] { "ACTION1", "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Credit, CardStatus.Active, false, new[] { "ACTION1", "ACTION3", "ACTION4", "ACTION5", "ACTION7", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13" })]
        [TestCase(CardType.Credit, CardStatus.Restricted, true, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9" })]
        [TestCase(CardType.Credit, CardStatus.Restricted, false, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9" })]
        [TestCase(CardType.Credit, CardStatus.Blocked, true, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION6", "ACTION7", "ACTION8", "ACTION9" })]
        [TestCase(CardType.Credit, CardStatus.Blocked, false, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION8", "ACTION9" })]
        [TestCase(CardType.Credit, CardStatus.Expired, true, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9" })]
        [TestCase(CardType.Credit, CardStatus.Expired, false, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9" })]
        [TestCase(CardType.Credit, CardStatus.Closed, true, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9" })]
        [TestCase(CardType.Credit, CardStatus.Closed, false, new[] { "ACTION3", "ACTION4", "ACTION5", "ACTION9" })]
        public async Task GetAllowedActionsHandler_ShouldReturnExpectedActions(CardType cardType, CardStatus cardStatus, bool isPinSet, string[] expectedActions)
        {
            //Arrange
            _cardServiceRepositoryMock.Setup(x => x.GetCardDetails(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new CardDetails("1234", cardType, cardStatus, isPinSet));

            var query = new GetAllowedActionsQuery("1234", "1234");
            var handler = CreateHandler();

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.That(result, Is.EquivalentTo(expectedActions));
        }

        [Test]
        public async Task GetAllowedActionsHandler_ShouldReturnNull_WhenNoDataIsReturnedFromRepository()
        {
            //Arrange
            _cardServiceRepositoryMock.Setup(x => x.GetCardDetails(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(value: null!);

            var query = new GetAllowedActionsQuery("1234", "1234");
            var handler = CreateHandler();

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetAllowedActionsHandler_ShouldThrow_WhenGetCardDetailsMethodThrows()
        {
            //Arrange
            _cardServiceRepositoryMock.Setup(x => x.GetCardDetails(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Some db error"));

            var query = new GetAllowedActionsQuery("1234", "1234");
            var handler = CreateHandler();

            //Act, Assert
            Assert.ThrowsAsync<Exception>(async () => await handler.Handle(query, CancellationToken.None));
        }

        private GetAllowedActionsHandler CreateHandler()
        {
            return new GetAllowedActionsHandler(_cardServiceRepositoryMock.Object);
        }
    }
}