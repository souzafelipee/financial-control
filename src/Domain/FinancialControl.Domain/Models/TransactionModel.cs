using FinancialControl.Domain.Enums;
using FinancialControl.Domain.Models.Base;
using System;

namespace FinancialControl.Domain.Models;

public class TransactionModel : DomainModel<Guid>
{
    public Guid AccountId { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime TransactionDate { get; set; }
}
