using MediatR;

namespace CreditCardAllowedActions.Application.Features.CreditCard.GetAllowedActions.Queries
{
    public record GetAllowedActionsQuery(string UserId, string CardNumber) : IRequest<List<string>>;
}
