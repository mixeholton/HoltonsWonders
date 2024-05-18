using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixeWonders.Model.Values
{
    public record UserValue(int? Id, string Name, AccountCreditDebit Account);
    public record CreditDebitValue(int? Id, string Description, decimal Amount, bool isCredit);
    public record AccountCreditDebit(List<CreditDebitValue> Credits, List<CreditDebitValue> Debits);
}
