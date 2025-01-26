using CreditCardAllowedActions.Domain.Enums;

namespace CreditCardAllowedActions.Domain.ValueObjects
{
    public record CardDetails(string CardNumber, CardType CardType, CardStatus CardStatus, bool IsPinSet);
}
