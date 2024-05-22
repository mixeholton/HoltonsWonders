namespace MixeWonders.Values.Entities;

public partial class RoleEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<AffiliationRole> AffiliationRoles { get; set; }
}
