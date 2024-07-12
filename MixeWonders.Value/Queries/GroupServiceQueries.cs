
using Microsoft.EntityFrameworkCore;
using MixeWonders.Values.Context;
using MixeWonders.Values.Values;


namespace MixeWonders.Values.Queries
{
    public class GroupServiceQueries
    {
        protected BrugsDbContext BrugsDbContext { get; }

        public GroupServiceQueries(BrugsDbContext brugsDbContext)
        {
            BrugsDbContext = brugsDbContext;
        }

        public async Task<IEnumerable<GroupValue>> GetAllGroups()
        {
            var groups = await BrugsDbContext.Groups.ToListAsync();
            return groups.Select(
                x => new GroupValue(
                    x.Id, 
                    x.Name, 
                    x.Roles.Select(r => new RoleValue(
                        r.Id, 
                        r.Name, 
                        r.Description, 
                        r.Permissions.Select(p => new PermissionValue(
                            p.Permission
                            )).ToList())
                    ).ToList()));
        }

    }
}

