using MixeWonders.Values.Enums;

namespace MixeWonders.Values.Values
{
    public record RoleValue(int? Id, string Name, string Description, List<PermissionValue> Permissions);
}
