using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Dtos;
using MixeWonders.Values.Entities;
using MixeWonders.Values.Services;
using MixeWonders.Values.Values;


namespace MixeWonders.Values.Commands
{
    public class UserServiceCommands
    {
        protected BrugsDbContext BrugsDbContext { get; }
        protected ScopeService ScopeService { get; }
        const string BRUGER_LOGON = "-BRUGER LOGON";
        const string SQLKEY_SYSTEM = "Scan Pro Data";

        public UserServiceCommands(BrugsDbContext brugsDbContext, ScopeService scopeService)
        {
            BrugsDbContext = brugsDbContext;
            ScopeService = scopeService;
        }

        public async Task CreateBrugsUserAccessAsync(List<UserValue> user)
        {
            var userIds = user.Select(x => x.Id).ToList();
            var UserStates = await BrugsDbContext.Users.Where(x => userIds.Contains(x.Id)).ToListAsync();
            var UserStateIds = UserStates.Select(x => x.Id).ToList();
            var NewUsers = user.Where(x => !UserStateIds.Contains(x.Id ?? 0));

            //await UpdateUserAsync(UserStates);


            var NewUserStates = NewUsers.Select(x => new UserEntity()
            {
                AffiliationId = x.AffiliationId,
                Name = x.Name,
                ChangedDate = DateTime.Now,
                CreditDebits = x.Account.Credits.Select(x => new CreditDebitEntity()
                {
                    Amount = x.Amount,
                    Description = x.Description,
                    isCredit = x.Balance                    
                }).Concat(x.Account.Debits.Select(x => new CreditDebitEntity()
                {
                    Amount = x.Amount,
                    Description = x.Description,
                    isCredit = x.Balance
                })).ToList(),
            }).ToList();

            await ScopeService.PerformTransaction(async x =>
            {

                await x.Users.AddRangeAsync(NewUserStates);
                await x.SaveChangesAsync();
            });
        }

        private async Task UpdateUserAsync(List<UserEntity> user)
        {
            var userIds = user.Select(x => x.Id).ToList();
            var UserStates = await BrugsDbContext.Users.Where(x => userIds.Contains(x.Id)).ToListAsync();



            //await ScopeService.PerformTransaction(async x =>
            //{

            //    await x.Logadgangs.AddAsync(logadgang);
            //    await x.SaveChangesAsync();
            //});
        }


    }
}
