using FactoryMethod.Enums;

namespace FactoryMethod.Models;

public class TransacaoBancaria
{
    public string NumeroOperacao { get; } = Guid.NewGuid().ToString();
    public string NomeCompleto { get; set; }
    public string Documento { get; set; }
    public decimal ValorTransacao { get; set; }
    public TipoTransacaoBancaria TipoTransacao { get; set; }    
    public DadosContaBancaria DadosConta { get; set; }
    public TipoContaBancaria TipoConta { get; set; }

    public static TransacaoBancaria TransacaoBancaria_1()
    {
        return new TransacaoBancaria
        {
            NomeCompleto = "Marinara da Silva",
            Documento = "87947428557",
            ValorTransacao = 5000.00M,
            TipoTransacao = TipoTransacaoBancaria.Deposito,
            TipoConta = TipoContaBancaria.ContaCorrente,
            DadosConta = new()
            {
                Agencia = "0234", Conta = "018293", Digito = "0"
            }
        };
    }
    public static TransacaoBancaria TransacaoBancaria_2()
    {
        return new TransacaoBancaria
        {
            NomeCompleto = "Yogi Cathh",
            Documento = "36206128890",
            ValorTransacao = 150.00M,
            TipoTransacao = TipoTransacaoBancaria.Transferencia,
            TipoConta = TipoContaBancaria.ContaCorrente,
            DadosConta = new()
            {
                Agencia = "0200",
                Conta = "075693",
                Digito = "4"
            }
        };
    }
    public static TransacaoBancaria TransacaoBancaria_3()
    {
        return new TransacaoBancaria
        {
            NomeCompleto = "Cami Brito",
            Documento = "86984623758",
            ValorTransacao = 5000.00M,
            TipoTransacao = TipoTransacaoBancaria.Saque,
            TipoConta = TipoContaBancaria.ContaCorrente,
            DadosConta = new()
            {
                Agencia = "0069",
                Conta = "0696969",
                Digito = "4"
            }
        };
    }
}

public class DadosContaBancaria
{
    public string Conta { get; set; }
    public string Digito { get; set; }
    public string Agencia { get; set; }
}
