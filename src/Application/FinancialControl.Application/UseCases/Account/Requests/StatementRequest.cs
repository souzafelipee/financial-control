using System;

namespace FinancialControl.Application.UseCases.Account.Requests;

public class StatementRequest
{
    public DateTime Date { get; set; }
    public Guid AccountId { get; set; } = Guid.Parse("136CA601-5C9C-4AD1-8CAA-95289F1A6131");
}
