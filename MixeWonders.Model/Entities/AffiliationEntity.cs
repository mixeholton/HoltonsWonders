using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Komit.MixeWonders.Model.Entities;

public partial class AffiliationEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public Collection<GroupEntity> Groups { get; set; }
    public Collection<RoleEntity> Roles { get; set; }

}
