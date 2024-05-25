using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Dtos;
using MixeWonders.Values.Entities;
using MixeWonders.Values.Services;
using MixeWonders.Values.Values;


namespace MixeWonders.Values.Commands
{
    public class GroupServiceCommands
    {
        protected BrugsDbContext BrugsDbContext { get; }
        protected ScopeService ScopeService { get; }

        public GroupServiceCommands(BrugsDbContext brugsDbContext, ScopeService scopeService)
        {
            BrugsDbContext = brugsDbContext;
            ScopeService = scopeService;
        }

        public async Task CreateGroupAsync(GroupValue group, List<RoleValue> roles)
        {
            var newGroup = new GroupEntity()
            {
                Name = group.Name,
                Roles = roles.Select(x => new RoleEntity()
                {
                    Id = x.Id ?? 0,
                    Description = x.Description,
                    Name = x.Name,
                    Permissions = x.Permissions.Select(x => new PermissionEntity()
                    {
                        Permission = x.Permission
                    }).ToList()
                }).ToList()
            };


            await ScopeService.PerformTransaction(async x =>
            {

                await x.Groups.AddRangeAsync();
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
