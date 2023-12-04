using FinancialControl.Domain.Enums;
using System;

namespace FinancialControl.Domain.Events;

public class RegisterTransactionEvent
{
    public Guid? CorrelationId { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public string TransactionDescription { get; set; }
    public decimal TransactionValue { get; set; }
}
