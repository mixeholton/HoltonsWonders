
using MixeWonders.Model.DbContexts;

using Microsoft.EntityFrameworkCore;
using System.Text;
using MixeWonders.Model.Values;
using System.Linq;


namespace MixeWonders.Model.Queries
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
            var users = await BrugsDbContext.Users.ToListAsync();
            var creditDebits = await BrugsDbContext.CreditDebit.ToListAsync();
            var AccountDictByUserId = creditDebits.ToDictionary(x => 
                    x.UserId, 
                    u => creditDebits.Where(x => x.UserId == u.UserId)
                        .Select(x => new CreditDebitValue(x.Id, x.Description, x.Amount, x.isCredit)).ToList());    
            
            return users.Select(x => new UserValue(x.Id, x.Name, new AccountCreditDebit(AccountDictByUserId[x.Id].Where(x => x.isCredit).ToList(), AccountDictByUserId[x.Id].Where(x => !x.isCredit).ToList())));
        }

    }    
}

