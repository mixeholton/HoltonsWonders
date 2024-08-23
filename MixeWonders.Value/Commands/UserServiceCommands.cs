using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Dtos;
using MixeWonders.Values.Entities;
using MixeWonders.Values.Queries;
using MixeWonders.Values.Services;
using MixeWonders.Values.Values;


namespace MixeWonders.Values.Commands
{
    public class UserServiceCommands
    {
        protected BrugsDbContext BrugsDbContext { get; }
        protected ScopeService ScopeService { get; }
        public UserServiceQueries UserServiceQueries { get; }

        public UserServiceCommands(BrugsDbContext brugsDbContext, ScopeService scopeService, UserServiceQueries userServiceQueries)
        {
            BrugsDbContext = brugsDbContext;
            ScopeService = scopeService;
            UserServiceQueries = userServiceQueries;
        }

        public async Task<CurrentUserValue?> CreateUserAsync(UserHeaderValue user, string? password = null)
        {
            var NewUser = new UserEntity()
            {
                Mail = user.Mail,
                Password = password != null ? password : $"{user.Mail[0].ToString().ToUpper()}{user.Mail[1].ToString().ToLower()}{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}",
                ChangedDate = DateTime.Now
            };
            var roles = await BrugsDbContext.Roles.ToListAsync();
            var groups = await BrugsDbContext.Groups.ToListAsync();
            var NewAffiliation = new AffiliationEntity()
            {
                User = NewUser,
                AffiliationRoles = roles,
                AffiliationGroups = groups
            };

            await ScopeService.PerformTransaction(async x =>
            {
                await x.Users.AddAsync(NewUser);
                await x.SaveChangesAsync();
            });

            await ScopeService.PerformTransaction(async x =>
            {
                await x.Affiliations.AddAsync(NewAffiliation);
                await x.SaveChangesAsync();
            });

            return await UserServiceQueries.GetCurrentUser(NewUser.Mail, NewUser.Password) ?? null;
        }
        public async Task UpdateUserAsync(UserHeaderValue user)
        {                                   
            var UpdateUser = new UserEntity()
            {                
                Mail = user.Mail,
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
                Mail = x.Mail,
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
