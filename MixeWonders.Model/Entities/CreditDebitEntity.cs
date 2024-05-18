using System;
using System.Collections.Generic;

namespace Komit.MixeWonders.Model.Entities;

public partial class CreditDebitEntity
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public bool isCredit { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }

}
