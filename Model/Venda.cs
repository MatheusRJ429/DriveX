namespace DriveX.Model;

public class Venda
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public int IdCarro { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public string NomeCarro { get; set; } = string.Empty;
    public DateOnly DataVenda { get; set; }
    public decimal ValorVenda { get; set; }
    public string FormaPagamento { get; set; } = string.Empty;
    public string StatusVenda { get; set; } = string.Empty;
}