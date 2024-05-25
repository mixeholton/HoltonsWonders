
using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Values;


namespace MixeWonders.Values.Queries
{
    public class UserServiceQueries
    {
        protected BrugsDbContext BrugsDbContext { get; }

        public UserServiceQueries(BrugsDbContext brugsDbContext)
        {
            BrugsDbContext = brugsDbContext;
        }

        public async Task<IEnumerable<UserValue>> GetAllUsers()
        {
            var users = await BrugsDbContext.Users.ToListAsync() ?? null;
            var creditDebits = await BrugsDbContext.CreditDebits.ToListAsync() ?? null;
            if(users == null || creditDebits == null)
                return new List<UserValue>();
            var AccountDictByUserId = creditDebits.ToDictionary(x =>
                    x.UserId,
                    u => creditDebits.Where(x => x.UserId == u.UserId)
                        .Select(x => new CreditDebitValue(x.Id, x.Description, x.Amount, x.isCredit)).ToList());

            return users.Select(x => new UserValue(x.Id, x.AffiliationId, x.Name, new AccountCreditDebit(AccountDictByUserId[x.Id].Where(x => x.Balance == Enums.BalanceCurrencyType.Credit).ToList(), AccountDictByUserId[x.Id].Where(x => x.Balance == Enums.BalanceCurrencyType.Debit).ToList())));
        }

    }
}

