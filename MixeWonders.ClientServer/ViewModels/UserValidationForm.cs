using MixeWonders.Values.Values;
using System.ComponentModel.DataAnnotations;

namespace Komit.CompanionApp.Component.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class UserValidationForm
    {
        public UserValue? userValue { get; set; }        
        public decimal BillAmountSum => userValue?.Account.Debits.Sum(x => x.Amount) - userValue.Account.Credits.Sum(x => x.Amount) ?? 0;

        public int? CreditDebitId {  get; set; }

        [Required(ErrorMessage = "Navn skal udfyldes")]
        [StringLength(30, ErrorMessage = "Navn max længde er på 30 tegn")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Kun bogstaver er tilladt i det fulde navn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Beskrivelse skal udfyldes")]
        [StringLength(40, ErrorMessage = "Beskrivelse max længde er på 40 tegn")]        
        public string Description { get; set; }

        [Required(ErrorMessage = "Beløb skal udfyldes")]
        [Range(0, double.MaxValue, ErrorMessage = "Beløb skal være ikke-negativt")]
        public decimal Amount { get; set; } = 0;
        public bool IsCredit { get; set; } = false;

        [Required(ErrorMessage = "Brugere skal udfyldes")]
        public IEnumerable<UserValue> CreditDebitUsers { get; set; } = new HashSet<UserValue>();
        public UserValidationForm(UserValue value)
        {
            this.Name = value.Name;
            this.Amount = 0;
            this.IsCredit = false;
            this.Description = "";
            this.CreditDebitId = null;
            this.CreditDebitUsers = new HashSet<UserValue>();
        } 
        public UserValidationForm()
        {
            this.userValue = null;
            this.CreditDebitId = null;
            this.CreditDebitUsers = new HashSet<UserValue>();
            this.Name = string.Empty;
            this.Amount = 0;
            this.Description = string.Empty;
            this.IsCredit = false;
        }        
        public UserValidationForm(UserValue? value, CreditDebitValue? bill, List<UserValue>? userValues)
        {
            this.Name = value?.Name ?? string.Empty;
            this.Amount = bill?.Amount ?? 0;
            this.IsCredit = (bill?.Balance ?? MixeWonders.Values.Enums.BalanceCurrencyType.None) == MixeWonders.Values.Enums.BalanceCurrencyType.Credit ? true : false;
            this.CreditDebitId = bill?.Id ?? 0;
            this.CreditDebitUsers = userValues ?? new List<UserValue>();
            this.Description = bill?.Description ?? string.Empty;
        }


    }

}
