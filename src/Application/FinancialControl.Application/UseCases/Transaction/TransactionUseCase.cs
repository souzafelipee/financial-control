using AutoMapper;
using FinancialControl.Application.Interfaces.UseCases;
using FinancialControl.Application.UseCases.Transaction.Requests;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Models;
using System.Threading.Tasks;

namespace FinancialControl.Application.UseCases.Transaction;

public class TransactionUseCase : IRegisterTransactionUseCase
{
    private IMapper Mapper { get; set; }
    private ITransactionRepo _transactionRepo;

    public TransactionUseCase(IMapper mapper, ITransactionRepo transactionRepo)
    {
        Mapper = mapper;
        _transactionRepo = transactionRepo;
    }

    public async Task RegisterTransaction(RegisterTransactionRequest request)
    {
        var transaction = Mapper.Map<TransactionModel>(request);
        await _transactionRepo.Insert(transaction);
    }
}
