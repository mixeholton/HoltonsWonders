using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Dtos;
using MixeWonders.Values.Entities;
using MixeWonders.Values.Services;
using MixeWonders.Values.Values;


namespace MixeWonders.Values.Commands
{
    public class PermissionServiceCommands
    {
        protected BrugsDbContext BrugsDbContext { get; }
        protected ScopeService ScopeService { get; }

        public PermissionServiceCommands(BrugsDbContext brugsDbContext, ScopeService scopeService)
        {
            BrugsDbContext = brugsDbContext;
            ScopeService = scopeService;
        }

        public async Task CreatePermissionAsync(PermissionValue permission)
        {

            var newPermission = new PermissionEntity() { Permission = permission.Permission };
            await ScopeService.PerformTransaction(async x =>
            {
                await BrugsDbContext.Permissions.AddAsync(newPermission);
                await x.SaveChangesAsync();
            });
        }

        public async Task DeletePermissionAsync(PermissionValue role)
        {           

            await ScopeService.PerformTransaction(async x =>
            {
                
                await x.SaveChangesAsync();
            });
        }


    }
}
