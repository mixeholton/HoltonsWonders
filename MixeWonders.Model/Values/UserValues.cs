namespace MixeWonders.Values.Values
{
    public record UserValue(int? Id, string Name, AccountCreditDebit Account);
    public record CreditDebitValue(int? Id, string Description, decimal Amount, bool isCredit);
    public record AccountCreditDebit(List<CreditDebitValue> Credits, List<CreditDebitValue> Debits);
}
