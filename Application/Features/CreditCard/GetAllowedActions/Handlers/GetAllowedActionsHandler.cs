using CreditCardAllowedActions.Application.Features.CreditCard.GetAllowedActions.Queries;
using CreditCardAllowedActions.Infrastructure.Persistence.Repositories.Interfaces;
using MediatR;

namespace CreditCardAllowedActions.Application.Features.CreditCard.GetAllowedActions.Handlers
{
    public class GetAllowedActionsHandler : IRequestHandler<GetAllowedActionsQuery, List<string>>
    {
        private readonly ICardServiceRepository _cardServiceRepository;

        public GetAllowedActionsHandler(ICardServiceRepository cardServiceRepository)
        {
            _cardServiceRepository = cardServiceRepository;
        }

        public async Task<List<string>> Handle(GetAllowedActionsQuery request, CancellationToken ct)
        {
            var cardDetails = await _cardServiceRepository.GetCardDetails(request.UserId, request.CardNumber, ct);

            if (cardDetails == null)
            {
                //$"Card with number {request.CardNumber} for user {request.UserId} not found.";
                //Handle null
            }

            return new List<string> { "ACTION1", "ACTION2", "ACTION3" };
        }
    }
}
