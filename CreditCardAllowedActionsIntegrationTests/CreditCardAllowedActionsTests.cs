using CreditCardAllowedActions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace CreditCardAllowedActionsIntegrationTests
{
    public class CreditCardAllowedActionsTests
    {
        private WebApplicationFactory<Program> _factory;
        private const string UserId = "User1";
        private const string CardNumber = "Card11";

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();
        }

        [Test]
        public async Task GetGetCreditCardAllowedActions_ShouldReturn200_WhenInputIsValidAndDataExists()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/credit-card/{UserId}/{CardNumber}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.That(response.Content.Headers.ContentType!.ToString(), Is.EqualTo("application/json; charset=utf-8"));
        }

        [Test]
        public async Task GetGetCreditCardAllowedActions_ShouldReturn494_WhenDataDoesNotExists()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/credit-card/Not/Exist");

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.NotFound);
            Assert.IsNull(response.Content.Headers.ContentType);
        }
    }
}