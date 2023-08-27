using FactoryMethod.Exceptions;
using FactoryMethod.Enums;
using FactoryMethod.Models;

namespace FactoryMethod.Implementations
{
    public class FactoryMethodClass2
    {
        public static void ExecutarTeste()
        {
            try {
                Pedido pedido = Pedido.Pedido4();
                PagamentoServiceFactory factory = new PagamentoServiceFactory();
                IPagamentoService paymentService = factory.ObterServicoPagamento(pedido.InformacaoPagamento.FormaPagamento);
                paymentService.ProcessarPagamento(pedido);
            } catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }
        }
    }




    #region [ Product ]

    /// <summary>
    /// Product
    /// </summary>
    public interface IPagamentoService
    {
        void ProcessarPagamento(Pedido pedido);
    }
    #endregion

    #region [ Concrete Product ]

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class CreditCardPaymentService : IPagamentoService
    {
        public void ProcessarPagamento(Pedido pedido)
        {
            // vai executar toda logica para o pagamento por cartão de credito
            Console.WriteLine("pagamento por cartão de credito");
        }
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class BankSlipPaymentService : IPagamentoService
    {
        public void ProcessarPagamento(Pedido pedido)
        {
            // vai executar toda logica para o pagamento por boleto
            Console.WriteLine("pagamento por boleto bancario");
        }
    }

    /// <summary>
    /// Concrete Product
    /// </summary>
    public class PixPaymentService : IPagamentoService
    {
        public void ProcessarPagamento(Pedido pedido)
        {
            // vai executar toda logica para o pagamento por PIX
            Console.WriteLine("pagamento por Pix");
        }
    }

    #endregion

    #region [ Factory Method ]

    public interface IPagamentoServiceFactory
    {
        IPagamentoService ObterServicoPagamento(TipoFormaPagamento tipoFormaPagamento);
    }

    /// <summary>
    /// Factory Method
    /// </summary>
    public class PagamentoServiceFactory : IPagamentoServiceFactory
    {
        private readonly CreditCardPaymentService _creditCardPaymentService;
        private readonly BankSlipPaymentService _bankSlipPaymentService;
        private readonly PixPaymentService _pixPaymentService;

        // não estou usando DependencyInjection, mas poderia usar aqui a injeção no construtor
        public PagamentoServiceFactory()
        {
            _creditCardPaymentService = new CreditCardPaymentService();
            _bankSlipPaymentService = new BankSlipPaymentService();
            _pixPaymentService = new PixPaymentService();
        }

        public IPagamentoService ObterServicoPagamento(TipoFormaPagamento tipoFormaPagamento)
        {
            switch (tipoFormaPagamento)
            {
                case TipoFormaPagamento.CartaoCredito: return _creditCardPaymentService;
                case TipoFormaPagamento.Boleto: return _bankSlipPaymentService;
                case TipoFormaPagamento.Pix: return _pixPaymentService;
                default: throw new InvalidPaymentMethodException("Metodo de pagamento inválido");
            }
        }
    }
    #endregion
}
