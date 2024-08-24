﻿using MixeWonders.Values.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MixeWonders.Values.Entities;

public class RoleEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<AffiliationEntity> Affiliations { get; set; } = new List<AffiliationEntity>();
    // Many-to-Many Relationship with GroupEntity
    public ICollection<GroupEntity> Groups { get; set; } = new List<GroupEntity>();

    // One-to-Many Relationship with PermissionEntity
    public ICollection<PermissionEntity> Permissions { get; set; } = new List<PermissionEntity>();
}
public class PermissionEntity
{
    public int Id { get; set; }
    public PermissionType Permission { get; set; }
}
