using CreditCardAllowedActions.Domain.ValueObjects;

namespace CreditCardAllowedActions.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface ICardServiceRepository
    {
        Task<CardDetails?> GetCardDetails(string userId, string cardNumber, CancellationToken ct = default);
    }
}