using FactoryMethod.Enums;
using FactoryMethod.Exceptions;
using FactoryMethod.Models;

namespace FactoryMethod.Implementations;


public class FactoryMethodClass3
{
    public static void ExecutarTeste()
    {
        TransacaoBancaria transacaoBancaria = TransacaoBancaria.TransacaoBancaria_1();
        TransacaoBancariaFactory factory = new TransacaoBancariaFactory();
        TransacaoBancariaService transacaoService = factory.CreateBankingTransaction(transacaoBancaria.TipoTransacaoBancaria);
        transacaoService.Executar(transacaoBancaria);
    }
}


public abstract class TransacaoBancariaService
{
    public abstract void Executar(TransacaoBancaria transacao);
}

public class DepositoTransactionService : TransacaoBancariaService
{
    public override void Executar(TransacaoBancaria transacao)
    {
        // vai executar toda logica para a transação bancária de deposito
        Console.WriteLine("Transação bancária de deposito");
    }
}

public class SaqueTransactionService : TransacaoBancariaService
{
    public override void Executar(TransacaoBancaria transacao)
    {
        // vai executar toda logica para a transação bancária de saque
        Console.WriteLine("Transação bancária de saque");
    }
}

public class TransferenciaTransactionService : TransacaoBancariaService
{
    public override void Executar(TransacaoBancaria transacao)
    {
        // vai executar toda logica para a transação bancária de transferencia
        Console.WriteLine("Transação bancária de transferência");
    }
}


public interface ITransacaoBancariaFactory
{
    TransacaoBancariaService CreateBankingTransaction(TipoTransacaoBancaria tipoTransacaoBancaria);
}

public class TransacaoBancariaFactory : ITransacaoBancariaFactory
{
    private readonly DepositoTransactionService _depositoService;
    private readonly SaqueTransactionService _saqueService;
    private readonly TransferenciaTransactionService _transferenciaService;


    // não estou usando DependencyInjection, mas poderia usar aqui a injeção no construtor
    public TransacaoBancariaFactory()
    {
        _depositoService = new DepositoTransactionService();
        _saqueService = new SaqueTransactionService();
        _transferenciaService = new TransferenciaTransactionService();
    }

    // instancia o objeto de acordo com o tipo de transacao bancaria realizada
    public TransacaoBancariaService CreateBankingTransaction(TipoTransacaoBancaria tipoTransacaoBancaria)
    {
        switch(tipoTransacaoBancaria)
        {
            case TipoTransacaoBancaria.Deposito: return _depositoService;
            case TipoTransacaoBancaria.Transferencia: return _transferenciaService;
            case TipoTransacaoBancaria.Saque: return _saqueService;
            default: throw new InvalidBankingTransactionException("Transação bancária inválida");
        }
    }
}