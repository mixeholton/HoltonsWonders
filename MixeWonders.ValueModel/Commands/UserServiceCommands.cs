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

        public UserServiceCommands(BrugsDbContext brugsDbContext, ScopeService scopeService)
        {
            BrugsDbContext = brugsDbContext;
            ScopeService = scopeService;
        }

        public async Task CreateUserAsync(UserHeaderValue user)
        {
            
            //await UpdateUserAsync(UserStates);


            var NewUser = new UserEntity()
            {                
                Name = user.Name,
                ChangedDate = DateTime.Now              
            };

            await ScopeService.PerformTransaction(async x =>
            {

                await x.Users.AddAsync(NewUser);
                await x.SaveChangesAsync();
            });
        }
        public async Task UpdateUserAsync(UserHeaderValue user)
        {                                   
            var UpdateUser = new UserEntity()
            {                
                Name = user.Name,
                ChangedDate = DateTime.Now
            };

            await ScopeService.PerformTransaction(async x =>
            {

                x.Users.Update(UpdateUser);
                await x.SaveChangesAsync();
            });
        }

        private async Task UpdateUserAsync(List<UserEntity> users)
        {
            var UpdateUserStates = users.Select(x => new UserEntity()
            {
                AffiliationId = x.AffiliationId,
                Name = x.Name,
                ChangedDate = DateTime.Now,
                CreditDebits = x.CreditDebits

            }).ToList();



            await ScopeService.PerformTransaction(async x =>
            {

                await x.Users.AddRangeAsync(UpdateUserStates);
                await x.SaveChangesAsync();
            });
        }


    }
}
