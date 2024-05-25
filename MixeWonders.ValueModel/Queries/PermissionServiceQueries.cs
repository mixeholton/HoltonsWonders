
using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Values;


namespace MixeWonders.Values.Queries
{
    public class PermissionServiceQueries
    {
        protected BrugsDbContext BrugsDbContext { get; }

        public PermissionServiceQueries(BrugsDbContext brugsDbContext)
        {
            BrugsDbContext = brugsDbContext;
        }

        public async Task<IEnumerable<PermissionValue>> GetAllPermissions()
        {
            var permissions = await BrugsDbContext.Permissions.ToListAsync() ?? null;            
            return permissions?.Select(x => new PermissionValue(x.Permission)) ?? new List<PermissionValue>();
        }

    }
}

