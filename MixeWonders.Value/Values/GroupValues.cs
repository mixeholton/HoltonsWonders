using MixeWonders.Values.Enums;

namespace MixeWonders.Values.Values
{
    public record GroupValue(int? Id, string Name, List<RoleValue> Roles);
}
