using FactoryMethod.Exceptions;
using FactoryMethod.Enums;
using FactoryMethod.Utils;

namespace FactoryMethod.Implementations;

public class FactoryMethodClass1
{
    public static void ExecutarTeste()
    {
        var factories = new List<PagamentoFactory>
        {
            new CartaoCreditoPagamentoFactory(),
            new PixPagamentoFactory()
        };

        foreach(var factory in factories)
        {
            var paymentService = factory.CriarPagamentoService();
            Console.WriteLine($"Metodo de pagamento: {paymentService} com taxa de transação de : {paymentService.TaxaTransacao}");
        }
    }
}


#region [ usando classe abstrata ]

/// <summary>
/// Product
/// </summary>
public abstract class PagamentoService
{
    public abstract int TaxaTransacao { get; }
    public abstract void ProcessarPagamento(decimal valor);
    public override string ToString() => GetType().Name;
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class CartaoCreditoPagamentoService : PagamentoService
{
    public override int TaxaTransacao => 2;

    public override void ProcessarPagamento(decimal valor)
    {
        var transactionAmount = Utilitarios.AplicarTaxa(valor, TaxaTransacao);
        
    }
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class BoletoPagamentoService : PagamentoService
{
    public override int TaxaTransacao => 5;

    public override void ProcessarPagamento(decimal valor)
    {
        var transactionAmount = Utilitarios.AplicarTaxa(valor, TaxaTransacao);
    }
}

/// <summary>
/// ConcreteProduct
/// </summary>
public class PixPagamentoService : PagamentoService
{
    public override int TaxaTransacao => 0;

    public override void ProcessarPagamento(decimal valor)
    {
        var transactionAmount = Utilitarios.AplicarTaxa(valor, TaxaTransacao);
    }
}


/// <summary>
/// Creator
/// </summary>
public abstract class PagamentoFactory
{
    public abstract PagamentoService CriarPagamentoService();
}


/// <summary>
/// ConcreteCreator
/// </summary>
public class CartaoCreditoPagamentoFactory : PagamentoFactory
{
    public override PagamentoService CriarPagamentoService()
    {
        return new CartaoCreditoPagamentoService();
    }
}

/// <summary>
/// ConcreteCreator
/// </summary>
public class BoletoPagamentoFactory : PagamentoFactory
{
    public override PagamentoService CriarPagamentoService()
    {
        return new BoletoPagamentoService();
    }
}

/// <summary>
/// ConcreteCreator
/// </summary>
public class PixPagamentoFactory : PagamentoFactory
{
    public override PagamentoService CriarPagamentoService()
    {
        return new PixPagamentoService();
    }
}
#endregion