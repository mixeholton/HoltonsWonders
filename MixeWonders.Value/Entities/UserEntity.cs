using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MixeWonders.Values.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }

    // One-to-One Relationship with AffiliationEntity
    public int? AffiliationId { get; set; }
    public AffiliationEntity? Affiliation { get; set; }

    public DateTime ChangedDate { get; set; }

    // One-to-Many Relationship with CreditDebitEntity
    public ICollection<CreditDebitEntity>? CreditDebits { get; set; } = new List<CreditDebitEntity>();
    // Many-to-Many Relationship with GroupEntity
}

