using FinancialControl.Domain.Enums;
using System;

namespace FinancialControl.Application.UseCases.Transaction.Requests;

public class RegisterTransactionRequest
{
    public TransactionTypeEnum TransactionType { get; set; }
    public string TransactionDescription { get; set; }
    public decimal TransactionValue { get; set; }
    public Guid AccountId { get; set; } = Guid.Parse("136CA601-5C9C-4AD1-8CAA-95289F1A6131");
}
