
using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Enums;
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

        public async Task<List<UserInfoValue>> GetAllUsers()
        {
            var users = await BrugsDbContext.Users.ToListAsync() ?? null;
            var creditDebits = await BrugsDbContext.CreditDebits.ToListAsync() ?? null;
            if(users == null || users.Count == 0 || creditDebits == null || creditDebits.Count == 0)
                return new List<UserInfoValue>();
            var AccountDictByUserId = creditDebits.ToDictionary(x =>
                    x.UserId,
                    u => creditDebits.Where(x => x.UserId == u.UserId)
                        .Select(x => new CreditDebitValue(x.Id, x.Description, x.Amount, x.isCredit)).ToList());

            return users.Select(x => new UserInfoValue(x.Id, x.AffiliationId, x.Mail, new AccountCreditDebit(AccountDictByUserId[x.Id].Where(x => x.Balance == Enums.BalanceCurrencyType.Credit).ToList(), AccountDictByUserId[x.Id].Where(x => x.Balance == Enums.BalanceCurrencyType.Debit).ToList()))).ToList();
        }
        public async Task<CurrentUserValue?> GetCurrentUser(string mail, string password)
        {
            var user = await BrugsDbContext.Users.SingleOrDefaultAsync(x => x.Mail == mail && x.Password == password);
            if (user == null) return null;
                        

            if (user == null)
                return null;
            return new CurrentUserValue(new UserValue(user.Id, user.Mail, user.Password), new List<RoleValue>()
            {
                new RoleValue(1, "Test", "Tester", Enum.GetValues(typeof(PermissionType)).Cast<PermissionType>().Where(x => x != PermissionType.Admin).ToList())
            });
        }
        public async Task<List<UserHeaderValue>> GetAllSimpelUsers()
        {
            var users = await BrugsDbContext.Users.ToListAsync();
            if(users.Count == 0)
                return new List<UserHeaderValue>();            

            return users.Select(x => new UserHeaderValue(x.Mail)).ToList();
        }

    }
}

