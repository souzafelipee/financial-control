using AutoMapper;
using FinancialControl.Application.Interfaces.UseCases;
using FinancialControl.Application.UseCases.Transaction.Requests;
using FinancialControl.Domain.Enums;
using FinancialControl.Domain.Interfaces.Repositories;
using FinancialControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialControl.Application.UseCases.Transaction;

public class TransactionUseCase : IRegisterTransactionUseCase
{
    private IMapper Mapper { get; set; }
    private ITransactionRepo _transactionRepo;
    private IAccountBalanceRepo _accountBalanceRepo;

    public TransactionUseCase(IMapper mapper, ITransactionRepo transactionRepo, IAccountBalanceRepo accountBalanceRepo)
    {
        Mapper = mapper;
        _transactionRepo = transactionRepo;
        _accountBalanceRepo = accountBalanceRepo;
    }

    public async Task RegisterTransaction(RegisterTransactionRequest request)
    {
        var transaction = Mapper.Map<TransactionModel>(request);
        await _transactionRepo.Insert(transaction);
        await SetBalance(request.AccountId, transaction.TransactionDate);
    }

    private async Task SetBalance(Guid accountId, DateTime transactionDate)
    {
        var previousDateAccountBalance = await _accountBalanceRepo.GetBalanceByDate(accountId, transactionDate.Date.AddDays(-1) );
        var previousDateBalance = previousDateAccountBalance?.Balance ?? 0;

        var transactions = await _transactionRepo.GetByDate(accountId, transactionDate.Date);
        var sumTransactions = transactions.Where(t => t.TransactionType == TransactionTypeEnum.Credit).Sum(t => t.Value)
            - transactions.Where(t => t.TransactionType == TransactionTypeEnum.Debit).Sum(t => t.Value);
        var accountBalance = await _accountBalanceRepo.GetBalanceByDate(accountId, transactionDate.Date);
        if (accountBalance == null)
        {
            accountBalance = new AccountBalanceModel()
            {
                AccountId = accountId,
                Balance = previousDateBalance + sumTransactions,
                BalanceDate = transactionDate.Date
            };
            await _accountBalanceRepo.Insert(accountBalance);
        }
        else
        {
            accountBalance.Balance = previousDateBalance + sumTransactions;
            await _accountBalanceRepo.Update(accountBalance);
        }
    }
}
