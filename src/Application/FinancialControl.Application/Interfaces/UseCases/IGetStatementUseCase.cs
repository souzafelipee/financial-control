using FinancialControl.Application.UseCases.Account.Requests;
using FinancialControl.Application.UseCases.Account.Responses;
using System.Threading.Tasks;

namespace FinancialControl.Application.Interfaces.UseCases;

public interface IGetStatementUseCase
{
    Task<StatementResponse> GetStatement(StatementRequest request);
}
