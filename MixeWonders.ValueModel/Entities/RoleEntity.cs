using MixeWonders.Values.Enums;

namespace MixeWonders.Values.Entities;

public partial class RoleEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<AffiliationRole> AffiliationRoles { get; set; } = new List<AffiliationRole>();
    public ICollection<PermissionEntity> Permissions { get; set; } = new List<PermissionEntity>();
}
public partial class PermissionEntity
{
    public int Id { get; set; }
    public PermissionType Permission { get; set; }
}
