using System.Collections.ObjectModel;

namespace MixeWonders.Values.Entities;

public partial class AffiliationEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public ICollection<AffiliationGroup> AffiliationGroups { get; set; }
    public ICollection<AffiliationRole> AffiliationRoles { get; set; }
}
public partial class AffiliationGroup
{
    public int AffiliationId { get; set; }
    public AffiliationEntity Affiliation { get; set; }

    public int GroupId { get; set; }
    public GroupEntity Group { get; set; }
}

public partial class AffiliationRole
{
    public int AffiliationId { get; set; }
    public AffiliationEntity Affiliation { get; set; }

    public int RoleId { get; set; }
    public RoleEntity Role { get; set; }
}
