using FinancialControl.Application.UseCases.Base;
using System.Collections.Generic;

namespace FinancialControl.Application.UseCases.Account.Responses
{
    public class StatementResponse
    {
        public IEnumerable<TransactionResponse> Transactions { get; set; }
        public decimal Balance { get; set; }
    }
}
