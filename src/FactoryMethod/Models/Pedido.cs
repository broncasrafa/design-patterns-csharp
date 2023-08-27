using FactoryMethod.Enums;

namespace FactoryMethod.Models;

public class Pedido
{
    public Cliente Cliente { get; set; }
    public List<ItemPedido> ItemsPedido { get; set; }
    public Endereco EnderecoEntrega { get; set; }
    public Endereco EnderecoPagamento { get; set; }
    public InformacaoPagamento InformacaoPagamento { get; set; }

    public static Pedido Pedido1()
    {
        return new Pedido
        {
            Cliente = new Cliente { Id = Guid.NewGuid(), Nome = "Cliente 1", Sobrenome = "Sobrenome 1", Email = "cliente1@teste.com", Documento = "28662424244" },
            EnderecoEntrega = new Endereco { Logradouro = "Rua 1", Numero = "20", Complemento = "casa 1", Bairro = "Jd. dos testes 1", Cidade = "São Paulo", Estado = "SP", Cep = "07900000" },
            EnderecoPagamento = new Endereco { Logradouro = "Rua 1", Numero = "20", Complemento = "casa 1", Bairro = "Jd. dos testes 1", Cidade = "São Paulo", Estado = "SP", Cep = "07900000" },
            InformacaoPagamento = new() { FormaPagamento = TipoFormaPagamento.CartaoCredito, NumeroCartao = "4571124578451240", DataExpiracao = "072028", Cvv = "450", NomeCompleto = "Cliente 1 Sobrenome 1" },
            ItemsPedido = new()
            {
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 450.99M },
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 190.90M }
            }
        };
    }
    public static Pedido Pedido2()
    {
        return new Pedido
        {
            Cliente = new Cliente { Id = Guid.NewGuid(), Nome = "Cliente 1", Sobrenome = "Sobrenome 1", Email = "cliente1@teste.com", Documento = "28662424244" },
            EnderecoEntrega = new Endereco { Logradouro = "Rua 1", Numero = "20", Complemento = "casa 1", Bairro = "Jd. dos testes 1", Cidade = "São Paulo", Estado = "SP", Cep = "07900000" },
            EnderecoPagamento = new Endereco { Logradouro = "Rua 1", Numero = "20", Complemento = "casa 1", Bairro = "Jd. dos testes 1", Cidade = "São Paulo", Estado = "SP", Cep = "07900000" },
            InformacaoPagamento = new() { FormaPagamento = TipoFormaPagamento.Boleto, NumeroCartao = "4571124578451240", DataExpiracao = "072028", Cvv = "450", NomeCompleto = "Cliente 1 Sobrenome 1" },
            ItemsPedido = new()
            {
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 10.99M },
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 90.90M },
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 4590M }
            }
        };
    }
    public static Pedido Pedido3()
    {
        return new Pedido
        {
            Cliente = new Cliente { Id = Guid.NewGuid(), Nome = "Cliente 1", Sobrenome = "Sobrenome 1", Email = "cliente1@teste.com", Documento = "28662424244" },
            EnderecoEntrega = new Endereco { Logradouro = "Rua 1", Numero = "20", Complemento = "casa 1", Bairro = "Jd. dos testes 1", Cidade = "São Paulo", Estado = "SP", Cep = "07900000" },
            EnderecoPagamento = new Endereco { Logradouro = "Rua 1", Numero = "20", Complemento = "casa 1", Bairro = "Jd. dos testes 1", Cidade = "São Paulo", Estado = "SP", Cep = "07900000" },
            InformacaoPagamento = new() { FormaPagamento = TipoFormaPagamento.Paypal, NumeroCartao = "4571124578451240", DataExpiracao = "072028", Cvv = "450", NomeCompleto = "Cliente 1 Sobrenome 1" },
            ItemsPedido = new()
            {
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 10.99M },
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 90.90M },
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 4590M }
            }
        };
    }
    public static Pedido Pedido4()
    {
        return new Pedido
        {
            Cliente = new Cliente { Id = Guid.NewGuid(), Nome = "Cliente 1", Sobrenome = "Sobrenome 1", Email = "cliente1@teste.com", Documento = "28662424244" },
            EnderecoEntrega = new Endereco { Logradouro = "Rua 1", Numero = "20", Complemento = "casa 1", Bairro = "Jd. dos testes 1", Cidade = "São Paulo", Estado = "SP", Cep = "07900000" },
            EnderecoPagamento = new Endereco { Logradouro = "Rua 1", Numero = "20", Complemento = "casa 1", Bairro = "Jd. dos testes 1", Cidade = "São Paulo", Estado = "SP", Cep = "07900000" },
            InformacaoPagamento = new() { FormaPagamento = TipoFormaPagamento.Pix, NumeroCartao = "4571124578451240", DataExpiracao = "072028", Cvv = "450", NomeCompleto = "Cliente 1 Sobrenome 1" },
            ItemsPedido = new()
            {
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 10.99M },
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 90.90M },
                new ItemPedido { ProdutoId = Guid.NewGuid(), Quantidade = 1, Preco = 4590M }
            }
        };
    }

}


public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public string Documento { get; set; }
}
public class ItemPedido
{
    public Guid ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}
public class Endereco
{
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
}
public class InformacaoPagamento
{
    public TipoFormaPagamento FormaPagamento { get; set; }
    public string NumeroCartao { get; set; }
    public string NomeCompleto { get; set; }
    public string DataExpiracao { get; set; }
    public string Cvv { get; set; }
}
