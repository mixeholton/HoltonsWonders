using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Dtos;
using MixeWonders.Values.Entities;
using MixeWonders.Values.Services;
using MixeWonders.Values.Values;


namespace MixeWonders.Values.Commands
{
    public class RoleServiceCommands
    {
        protected BrugsDbContext BrugsDbContext { get; }
        protected ScopeService ScopeService { get; }

        public RoleServiceCommands(BrugsDbContext brugsDbContext, ScopeService scopeService)
        {
            BrugsDbContext = brugsDbContext;
            ScopeService = scopeService;
        }

        public async Task CreateRoleAsync(RoleValue userRole)
        {
            var Types = userRole.Permissions;
            var permission = await BrugsDbContext.Permissions.Where(x => Types.Contains(x.Permission)).ToListAsync();
            var role = new RoleEntity()
            {
                Name = userRole.Name,
                Description = userRole.Description,
                Permissions = permission
            };

            await ScopeService.PerformTransaction(async x =>
            {
                await x.Roles.AddAsync(role);
                await x.SaveChangesAsync();
            });
        }

        public async Task UpdateRoleAsync(RoleEntity role)
        {           

            await ScopeService.PerformTransaction(async x =>
            {
                
                await x.SaveChangesAsync();
            });
        }


    }
}
