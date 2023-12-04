using AutoMapper;
using FinancialControl.Application.Interfaces.UseCases;
using FinancialControl.Application.UseCases.Transaction.Requests;
using FinancialControl.Domain.Events;
using MassTransit;
using Serilog;

namespace FinancialControl.Application.Consumers;

public class RegisterTransactionConsumer : IConsumer<RegisterTransactionEvent>
{
    private readonly IRegisterTransactionUseCase _registerTransactionUseCase;
    private IMapper Mapper { get; set; }
    public RegisterTransactionConsumer(IRegisterTransactionUseCase registerTransactionUseCase, IMapper mapper)
    {
        _registerTransactionUseCase = registerTransactionUseCase;
        Mapper = mapper;
    }

    public async Task Consume(ConsumeContext<RegisterTransactionEvent> context)
    {
        try
        {
            Log.Debug("Mensagem Recebida: {@message}", context.Message);

            var request = Mapper.Map<RegisterTransactionRequest>(context.Message);
            await _registerTransactionUseCase.RegisterTransaction(request);

            Log.Debug("Mensagem {@message} processada com sucesso", context.Message);


        }
        catch (Exception ex)
        {
            Log.Error(ex, "Erro no consumer {consumer}", nameof(RegisterTransactionConsumer));
            throw;
        }
    }
}