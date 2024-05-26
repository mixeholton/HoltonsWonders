using MixeWonders.Values.Enums;

namespace MixeWonders.Values.Values
{
    public record UserHeaderValue(string Name);
    public record UserValue(int? Id,int? AffiliationId, string Name, AccountCreditDebit Account);
    public record CreditDebitValue(int? Id, string Description, decimal Amount, BalanceCurrencyType Balance);
    public record AccountCreditDebit(List<CreditDebitValue> Credits, List<CreditDebitValue> Debits);
}
