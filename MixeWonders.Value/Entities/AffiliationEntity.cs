using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MixeWonders.Values.Entities;

public class AffiliationEntity
{
    public int Id { get; set; }

    public int? UserId { get; set; }
    // One-to-One Relationship with UserEntity (managed by UserEntity)
    public UserEntity User { get; set; }

    // Many-to-Many Relationship with GroupEntity
    public ICollection<GroupEntity> Groups { get; set; } = new List<GroupEntity>();

    // Many-to-Many Relationship with RoleEntity
    public ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
    
}
