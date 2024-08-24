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
        private async Task CreatAffiliation(UserEntity user)
        {
            var roles = await BrugsDbContext.Roles.ToListAsync();
            var groups = await BrugsDbContext.Groups.ToListAsync();
            roles.ForEach(x => x.Id = 0);
            groups.ForEach(x => x.Id = 0);
            user.Id = 0;
            var NewAffiliation = new AffiliationEntity()
            {                
                User = user,
                Roles = roles,
                Groups = groups
            };

            await ScopeService.PerformTransaction(async x =>
            {
                await x.Affiliations.AddAsync(NewAffiliation);
                await x.SaveChangesAsync();
            });
        }

        public async Task<CurrentUserValue?> CreateUserAsync(UserHeaderValue user, string? password = null)
        {
            var roles = await BrugsDbContext.Roles.AsNoTracking().ToListAsync(); // These roles are now tracked by EF Core
            var groups = await BrugsDbContext.Groups.AsNoTracking().ToListAsync(); // Same for groups
            var newUser = new UserEntity()
            {
                Mail = user.Mail,
                Password = password != null
                    ? password
                    : $"{user.Mail[0].ToString().ToUpper()}{user.Mail[1].ToString().ToLower()}{DateTime.Now.Day}{DateTime.Now.Month}{DateTime.Now.Year}",
                ChangedDate = DateTime.Now,
            };

            var newAffiliation = new AffiliationEntity()
            {
                User = newUser
            };
            
            // Save everything in one transaction
            await ScopeService.PerformTransaction(async x =>
            {
                await x.Users.AddAsync(newUser); // Only newUser is actually a new entity
                await x.Affiliations.AddAsync(newAffiliation);
                await x.SaveChangesAsync();
            });
            newUser.Groups = groups;
            newUser.Affiliation = newAffiliation;
            newAffiliation.User = newUser;
            newAffiliation.Roles = roles;
            newAffiliation.Groups = groups;
            await UpdateUserAsync(newUser, newAffiliation);

            return await UserServiceQueries.GetCurrentUser(newUser.Mail, newUser.Password) ?? null;
        }
        public async Task UpdateUserAsync(UserEntity user, AffiliationEntity affiliation)
        {                                               
            await ScopeService.PerformTransaction(async x =>
            {
                x.Users.Update(user);
                x.Affiliations.Update(affiliation);
                await x.SaveChangesAsync();
            });
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
