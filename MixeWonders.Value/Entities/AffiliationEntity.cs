using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MixeWonders.Values.Entities;

public class AffiliationEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public  UserEntity User { get; set; }
    public ICollection<GroupEntity> AffiliationGroups { get; set; } = new List<GroupEntity>();
    public ICollection<RoleEntity> AffiliationRoles { get; set; } = new List<RoleEntity>();
}
