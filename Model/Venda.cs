

namespace DriveX.Model;

public class Venda
{
    // ID único da venda.
    public int Id { get; set; }

    // ID do cliente que realizou a compra.
    public int IdCliente { get; set; }

    // ID do carro que foi vendido.
    public int IdCarro { get; set; }

    // Nome do cliente que realizou a compra.
    public string NomeCliente { get; set; } = string.Empty;

    // Nome ou modelo do carro vendido.
    public string NomeCarro { get; set; } = string.Empty;

    // Data em que a venda foi realizada.
    public DateOnly DataVenda { get; set; }

    // Valor total da venda.
    // decimal é utilizado para trabalhar com valores monetários.
    public decimal ValorVenda { get; set; }

    // Forma de pagamento utilizada na venda.
    // Exemplo: "À vista", "Financiamento" ou "Cartão".
    public string FormaPagamento { get; set; } = string.Empty;

    // Situação atual da venda.
    // Exemplo: "Concluída", "Pendente" ou "Cancelada".
    public string StatusVenda { get; set; } = string.Empty;
}