using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Dtos;
using MixeWonders.Values.Entities;
using MixeWonders.Values.Services;
using MixeWonders.Values.Values;
using System.Linq;


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
            RoleEntity role = await SetRole(userRole);
            await ScopeService.PerformTransaction(async x =>
            {
                await x.Roles.AddAsync(role);
                await x.SaveChangesAsync();
            });
            var Types = userRole.Permissions;
            var permissions = await BrugsDbContext.Permissions.Where(x => Types.Contains(x.Permission)).ToListAsync();
            role.Permissions = permissions;
            await ScopeService.PerformTransaction(async x =>
            {
                x.Roles.Update(role);
                await x.SaveChangesAsync();
            });
        }

        public async Task UpdateRoleAsync(RoleValue userRole)
        {
            RoleEntity role = await SetRole(userRole);
            await ScopeService.PerformTransaction(async x =>
            {
                x.Roles.Update(role);
                await x.SaveChangesAsync();
            });
        }

        private async Task<RoleEntity> SetRole(RoleValue userRole)
        {
            
            var role = new RoleEntity()
            {
                Name = userRole.Name,
                Description = userRole.Description,                
            };
                        
            return role;
        }
    }
}
