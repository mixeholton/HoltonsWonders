
using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Values;


namespace MixeWonders.Values.Queries
{
    public class RoleServiceQueries
    {
        protected BrugsDbContext BrugsDbContext { get; }

        public RoleServiceQueries(BrugsDbContext brugsDbContext)
        {
            BrugsDbContext = brugsDbContext;
        }

        public async Task<IEnumerable<RoleValue>> GetAllRoles()
        {
            var roles = await BrugsDbContext.Roles.ToListAsync();
            return roles.Select(x => new RoleValue(x.Id, x.Name, x.Description, x.Permissions.Select(p => new PermissionValue(p.Permission)).ToList()));
        }

    }
}

