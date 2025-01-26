using CreditCardAllowedActions.Application.Features.CreditCard.GetAllowedActions.Queries;
using MediatR;

namespace CreditCardAllowedActions.Presentation
{
    public static class CreditCardEndpointsExtensions
    {
        public static void MapCreditCardEndpoints(this WebApplication app)
        {
            app.MapGet(
                "/credit-card/{userId}/{cardNumber}", 
                async (string userId, string cardNumber, IMediator mediator, CancellationToken ct = default) => 
                { 
                    var query = new GetAllowedActionsQuery(userId, cardNumber);
                    var result = await mediator.Send(query, ct);
                    return Results.Ok(result); 
                })
                .WithName("GetCreditCardAllowedActions")
                .WithOpenApi();
        }
    }
}
