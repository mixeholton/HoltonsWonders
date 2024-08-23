

using MixeWonders.Values.Commands;
using MixeWonders.Values.Enums;
using MixeWonders.Values.Queries;
using MixeWonders.Values.Values;

namespace MixeWonders.Values.Services
{
    public class DatabaseSeeder
    {
        private readonly UserService _userService;
        private readonly GroupService _groupService;
        private readonly RoleService _roleService;
        private readonly PermissionService _permissionService;

        public DatabaseSeeder(
            UserService userService,
            GroupService groupService,
            RoleService roleService,
            PermissionService permissionService)
        {
            _userService = userService;
            _groupService = groupService;
            _roleService = roleService;
            _permissionService = permissionService;
        }
        public async Task SeedAsync()
        {
            //Permissions
            //foreach (var permissionType in Enum.GetValues(typeof(PermissionType)).Cast<PermissionType>())
            //{
            //    await _permissionService.Commands.CreatePermissionAsync(new PermissionValue(permissionType));
            //}
            ////Roles
            //await _roleService.Commands.CreateRoleAsync(new RoleValue(null, "Admin", "Adminstrator",
            //    new List<PermissionType>() { PermissionType.Admin, PermissionType.Permissions, PermissionType.Users }));
            //await _roleService.Commands.CreateRoleAsync(new RoleValue(null, "Basic", "Basic Permisssions",
            //    new List<PermissionType>() { PermissionType.Home, PermissionType.Counter, PermissionType.Bill, PermissionType.None }));
            //await _roleService.Commands.CreateRoleAsync(new RoleValue(null, "Footballer", "Only FootballFans",
            //    new List<PermissionType>() { PermissionType.Football }));
            //await _roleService.Commands.CreateRoleAsync(new RoleValue(null, "Advanced User", "Benificial User",
            //    new List<PermissionType>() { PermissionType.BoardGames, PermissionType.SplitAdvanced, PermissionType.Scheduler }));
            //await _roleService.Commands.CreateRoleAsync(new RoleValue(null, "Super", "Super Adminstrator",
            //    new List<PermissionType>() { PermissionType.Super }));
            //var roles = await _roleService.Queries.GetAllRoles();
            ////Groups
            //await _groupService.Commands.CreateGroupAsync(
            //    new GroupValue(null, "User", 
            //        roles.Where(x => x.Name == "Basic" || x.Name == "Footballer").Select(r => new RoleValue(r.Id, r.Name, r.Description, r.Permissions)).ToList()));
            //await _groupService.Commands.CreateGroupAsync(
            //    new GroupValue(null, "Advanced Footballer", 
            //        roles.Where(x => x.Name == "Basic" || x.Name == "Advanced User" || x.Name == "Footballer").Select(r => new RoleValue(r.Id, r.Name, r.Description, r.Permissions)).ToList()));
            //await _groupService.Commands.CreateGroupAsync(
            //    new GroupValue(null, "Super Admin",
            //        roles.Where(x => x.Name == "Basic" || x.Name == "Super" || x.Name == "Admin").Select(r => new RoleValue(r.Id, r.Name, r.Description, r.Permissions)).ToList())); 
            //await _groupService.Commands.CreateGroupAsync(
            //    new GroupValue(null, "All",
            //        roles.Select(r => new RoleValue(r.Id, r.Name, r.Description, r.Permissions)).ToList()));

            //var currentUser = await _userService.Commands.CreateUserAsync(new UserHeaderValue("mixeholton77@gmail.com"), "Komit12345");



        }
    }
}
