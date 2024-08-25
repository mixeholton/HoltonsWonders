
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MixeWonders.Values.Entities;

public class GroupEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Many-to-Many Relationship with UserEntity
    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    // Many-to-Many Relationship with RoleEntity
    public ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
}
