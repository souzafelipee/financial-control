using FinancialControl.Domain.Enums;
using System;

namespace FinancialControl.Application.UseCases.Base;

public class TransactionResponse
{
    public Guid Id { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public DateTime TransactionDate { get; set; }
}
