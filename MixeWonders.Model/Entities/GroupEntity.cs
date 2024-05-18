using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Komit.MixeWonders.Model.Entities;

public partial class GroupEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AffiliationId { get; set; }
    public AffiliationEntity Affiliation { get; set; }
    public Collection<RoleEntity> Roles { get; set; }
}
