using FinancialControl.Application.UseCases.Transaction.Requests;
using System.Threading.Tasks;

namespace FinancialControl.Application.Interfaces.UseCases
{
    public interface IRegisterTransactionUseCase
    {
        Task RegisterTransaction(RegisterTransactionRequest request);
    }
}
