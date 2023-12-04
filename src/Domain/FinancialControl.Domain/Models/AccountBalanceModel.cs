using FinancialControl.Domain.Models.Base;
using System;

namespace FinancialControl.Domain.Models
{
    public class AccountBalanceModel : DomainModel
    {
        public Guid AccountId { get; set; }
        public decimal Balance { get; set; }
        public DateTime BalanceDate { get; set; }
    }
}
