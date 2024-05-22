using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MixeWonders.Values.Entities;

public partial class AffiliationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public  UserEntity User { get; set; }
    public ICollection<AffiliationGroup> AffiliationGroups { get; set; } = new List<AffiliationGroup>();
    public ICollection<AffiliationRole> AffiliationRoles { get; set; } = new List<AffiliationRole>();
}
public partial class AffiliationGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int AffiliationId { get; set; }
    public AffiliationEntity Affiliation { get; set; }

    public int GroupId { get; set; }
    public GroupEntity Group { get; set; }
}

public partial class AffiliationRole
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int AffiliationId { get; set; }
    public AffiliationEntity Affiliation { get; set; }

    public int RoleId { get; set; }
    public RoleEntity Role { get; set; }
}
