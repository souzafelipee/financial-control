using AutoMapper;
using FinancialControl.Application.Interfaces.UseCases;
using FinancialControl.Application.UseCases.Account.Requests;
using FinancialControl.Application.UseCases.Account.Responses;
using FinancialControl.Application.UseCases.Base;
using FinancialControl.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialControl.Application.UseCases.Account;

public class AccountUseCase : IGetStatementUseCase
{
    private IMapper Mapper {  get; set; }
    private ITransactionRepo _transactionRepo;
    private IAccountBalanceRepo _accountBalanceRepo;

    public AccountUseCase(
        IAccountBalanceRepo accountBalanceRepo,
        ITransactionRepo transactionRepo,
        IMapper mapper)
    {
        Mapper = mapper;
        _transactionRepo = transactionRepo;
        _accountBalanceRepo = accountBalanceRepo;
    }

    public async Task<StatementResponse> GetStatement(StatementRequest request)
    {
        var transactions = await _transactionRepo.GetByDate(request.AccountId, request.Date.Date);
        var transactionsResponse = Mapper.Map<IEnumerable<TransactionResponse>>(transactions);

        var balance = await _accountBalanceRepo.GetBalanceByDate(request.AccountId, request.Date.Date);
        return new StatementResponse
        {
            Transactions = transactionsResponse,
            Balance = balance?.Balance ?? 0
        };
    }
}
