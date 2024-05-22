using System.Collections.ObjectModel;

namespace MixeWonders.Values.Entities;

public partial class UserEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AffiliationId { get; set; }
    public AffiliationEntity Affiliation { get; set; }
    public DateTime? ChangedDate { get; set; }
    public ICollection<CreditDebitEntity> CreditDebits { get; set; }
}

