using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MixeWonders.Values.Entities;

public class UserEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Mail { get; set; }
    public string Password { get; set; }
    public int? AffiliationId { get; set; }
    public AffiliationEntity? Affiliation { get; set; }
    public DateTime ChangedDate { get; set; }
    public ICollection<CreditDebitEntity>? CreditDebits { get; set; } = null;
}

