
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MixeWonders.Values.Entities;

public class GroupEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    public ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
}
