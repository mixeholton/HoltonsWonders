using MixeWonders.Values.Entities;
using MixeWonders.Values.Enums;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace MixeWonders.Values.Values
{
    public interface IWireFrameValues
    {
        
    }

    public record UserHeaderValue(string Mail) : IWireFrameValues;
    public record UserInfoValue(int? Id,int? AffiliationId, string Mail, AccountCreditDebit Account) : IWireFrameValues;
    public record CreditDebitValue(int? Id, string Description, decimal Amount, BalanceCurrencyType Balance);
    public record AccountCreditDebit(List<CreditDebitValue> Credits, List<CreditDebitValue> Debits);   
    public record CurrentUserValue(UserValue User, List<RoleValue> Affiliations)
    {        
        public bool IsValid(PermissionType permission) => this != null && Affiliations.Any(x => x.Permissions.Contains(permission));

        public List<PermissionType> Permissions => Affiliations.SelectMany(x => x.Permissions).Distinct().ToList();
    };
    public record UserValue(int? BrugsId, string Mail, string Password)
    {
        public bool IsValid => BrugsId != null;
    }
}
