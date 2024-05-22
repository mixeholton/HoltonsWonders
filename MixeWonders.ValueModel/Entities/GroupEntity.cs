
namespace MixeWonders.Values.Entities;

public partial class GroupEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<RoleEntity> Roles { get; set; }
    public ICollection<AffiliationGroup> AffiliationGroups { get; set; } = new List<AffiliationGroup>();
}
