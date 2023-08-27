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
        TransacaoBancariaService transacaoService = factory.CreateTransaction(transacaoBancaria.TipoTransacao);
        transacaoService.Executar(transacaoBancaria);
    }
}




/**
👉🏾 Disponibiliza uma interface para criar objetos em uma superclasse, o chamado Factory, deixando ela a cargo de decidir o tipo de 
objeto a ser criado.
👉🏾 A cada novo objeto a ser inserido na logica da aplicação, a superclasse será atualizada, não impactando os clientes (o código
que estará chamado essa superclasse) dela.

Neste padrão, voce deve substituir as chamadas diretas (new) da construção de objetos da classe,
para um metódo intermediario que fará o papel de fabrica, e o metodo de fabrica irá controlar 
como criar os objetos, ele irá fabricar as classes concretas ou produtos.
- a aplicação conversa com o FactoryMethod e ele irá produzir as classes concretas

Dessa forma, você tem uma estrutura flexível que permite criar diferentes tipos de transações de 
forma isolada e extensível, mantendo a coesão e o baixo acoplamento entre as classes. 


▪️ o problema: grande utilização de estruturas condicionais para criação de objetos e decidir qual instancia de classe utilizar,
            ou seja, a cada nova classe a ser utilizada, mais uma condicional será adicionada e a classe ficará cada vez mais
            complexa e maior.

▪️ no exemplo: No contexto de transações bancárias, recebe os dados da transação, extrai os dados e decide como proceder. E conforme
            o negocio vai crescendo, havera a necessidade frequente de adicionar novos tipos de transações bancárias. Você pode aplicar esse 
            padrão para criar diferentes tipos de transações, como depósitos, saques e transferências, de forma flexível e extensível. 
*/


// Product
public abstract class TransacaoBancariaService
{
    public abstract void Executar(TransacaoBancaria transacao);
}

// ConcreteProduct
public class DepositoTransactionService : TransacaoBancariaService
{
    public override void Executar(TransacaoBancaria transacao)
    {
        // vai executar toda logica para a transação bancária de deposito
        Console.WriteLine("Transação bancária de deposito");
    }
}

// ConcreteProduct
public class SaqueTransactionService : TransacaoBancariaService
{
    public override void Executar(TransacaoBancaria transacao)
    {
        // vai executar toda logica para a transação bancária de saque
        Console.WriteLine("Transação bancária de saque");
    }
}

// ConcreteProduct
public class TransferenciaTransactionService : TransacaoBancariaService
{
    public override void Executar(TransacaoBancaria transacao)
    {
        // vai executar toda logica para a transação bancária de transferencia
        Console.WriteLine("Transação bancária de transferência");
    }
}


// FactoryMethod
public interface ITransacaoBancariaFactory
{
    TransacaoBancariaService CreateTransaction(TipoTransacaoBancaria tipoTransacaoBancaria);
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
    public TransacaoBancariaService CreateTransaction(TipoTransacaoBancaria tipoTransacaoBancaria)
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