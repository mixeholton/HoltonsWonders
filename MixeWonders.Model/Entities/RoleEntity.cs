using System;
using System.Collections.Generic;

namespace Komit.MixeWonders.Model.Entities;

public partial class RoleEntity
{
    public int Id { get; set; }
    public string Name { get; set; }    
    public string Description { get; set; }
    public int AffiliationId { get; set; }
    public AffiliationEntity Affiliation { get; set; }
    
}
