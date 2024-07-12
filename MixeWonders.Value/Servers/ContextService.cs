

using MixeWonders.Values.Commands;
using MixeWonders.Values.Queries;

namespace MixeWonders.Values.Services
{
    public record UserService(UserServiceCommands Commands, UserServiceQueries Queries);
    public record GroupService(GroupServiceCommands Commands, GroupServiceQueries Queries);
    public record RoleService(RoleServiceCommands Commands, RoleServiceQueries Queries);
    public record PermissionService(PermissionServiceCommands Commands, PermissionServiceQueries Queries);
}
