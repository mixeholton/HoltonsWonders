using MixeWonders.Values.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MixeWonders.Values.Entities;

public partial class CreditDebitEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public BalanceCurrencyType isCredit { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}
