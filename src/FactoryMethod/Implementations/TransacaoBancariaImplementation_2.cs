namespace FactoryMethod.Implementations;


public class FactoryMethodClass4
{
    public static void ExecutarTeste()
    {
        // nestes exemplos não usei parametros para definir o tipo de transação mas segue a mesma idéia para usar a factory
        ITransactionFactory factory = new DepositTransactionFactory();
        Transaction transaction = factory.CreateTransaction();
        transaction.ProccessTransaction();

        // Você pode trocar a factory para criar outros tipos de transações
        factory = new WithdrawTransactionFactory();
        transaction = factory.CreateTransaction();
        transaction.ProccessTransaction();
    }
}



/// <summary>
/// classe base
/// </summary>
public abstract class Transaction
{
    public abstract void ProccessTransaction();
}

/// <summary>
/// subclasse concreta. Cada uma dessas subclasses representará um tipo específico de transação.
/// </summary>
public class DepositTransaction : Transaction
{
    public override void ProccessTransaction()
    {
        Console.WriteLine("processando uma transação de deposito");
    }
}

public class WithdrawTransaction : Transaction
{
    public override void ProccessTransaction()
    {
        Console.WriteLine("processando uma transação de saque");
    }
}

public class TransferTransaction : Transaction
{
    public override void ProccessTransaction()
    {
        Console.WriteLine("processando uma transação de transferência");
    }
}


/// <summary>
/// Interface de fabrica, que declare um método para criar transações. 
/// Cada tipo de transação terá sua própria classe de fábrica que implementará essa interface.
/// </summary>
public interface ITransactionFactory
{
    Transaction CreateTransaction();
}

public class DepositTransactionFactory : ITransactionFactory
{
    public Transaction CreateTransaction()
    {
        return new DepositTransaction();
    }
}

public class WithdrawTransactionFactory : ITransactionFactory
{
    public Transaction CreateTransaction()
    {
        return new WithdrawTransaction();
    }
}

public class TransferTransactionFactory : ITransactionFactory
{
    public Transaction CreateTransaction()
    {
        return new TransferTransaction();
    }
}