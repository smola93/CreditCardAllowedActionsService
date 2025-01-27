using CreditCardAllowedActions.Domain.Enums;

namespace CreditCardAllowedActions.Domain.ValueObjects
{
    public record CardDetails(string CardNumber, CardType CardType, CardStatus CardStatus, bool IsPinSet)
    {
        public List<string> GetAllowedActions()
        {
            var actions = new List<string>();

            // Logic based on card status
            switch (CardStatus)
            {
                case CardStatus.Ordered:
                    actions.AddRange(["ACTION3", "ACTION4", "ACTION8", "ACTION9", "ACTION10", "ACTION12", "ACTION13"]);
                    if (IsPinSet)
                    {
                        actions.Add("ACTION6");
                    }
                    else
                    {
                        actions.Add("ACTION7");
                    }

                    if (CardType == CardType.Credit)
                    {
                        actions.Add("ACTION5");
                    }
                    break;

                case CardStatus.Inactive:
                    actions.AddRange(["ACTION2", "ACTION3", "ACTION4", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13"]);
                    if (IsPinSet)
                    {
                        actions.Add("ACTION6");
                    }
                    else
                    {
                        actions.Add("ACTION7");
                    }

                    if (CardType == CardType.Credit)
                    {
                        actions.Add("ACTION5");
                    }
                    break;

                case CardStatus.Active:
                    actions.AddRange(["ACTION1", "ACTION3", "ACTION4", "ACTION8", "ACTION9", "ACTION10", "ACTION11", "ACTION12", "ACTION13"]);
                    if (IsPinSet)
                    {
                        actions.Add("ACTION6");
                    }
                    else
                    {
                        actions.Add("ACTION7");
                    }

                    if (CardType == CardType.Credit)
                    {
                        actions.Add("ACTION5");
                    }
                    break;

                case CardStatus.Restricted:
                    actions.AddRange(["ACTION3", "ACTION4", "ACTION9"]);

                    if (CardType == CardType.Credit)
                    {
                        actions.Add("ACTION5");
                    }
                    break;

                case CardStatus.Blocked:
                    actions.AddRange(["ACTION3", "ACTION4", "ACTION8", "ACTION9"]);

                    if (IsPinSet)
                    {
                        actions.Add("ACTION6");
                        actions.Add("ACTION7");
                    }

                    if (CardType == CardType.Credit)
                    {
                        actions.Add("ACTION5");
                    }
                    break;

                case CardStatus.Expired:
                    actions.AddRange(["ACTION3", "ACTION4", "ACTION9"]);

                    if (CardType == CardType.Credit)
                    {
                        actions.Add("ACTION5");
                    }
                    break;

                case CardStatus.Closed:
                    actions.AddRange(["ACTION3", "ACTION4", "ACTION9"]);

                    if (CardType == CardType.Credit)
                    {
                        actions.Add("ACTION5");
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(CardStatus), CardStatus, "Unknown card status.");
            }

            return actions;
        }
    };
}
