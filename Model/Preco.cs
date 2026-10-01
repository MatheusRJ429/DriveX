
namespace DriveX.Model;

public class Preco
{
    // ID único do registro de preço.
    public int Id { get; set; }

    // ID do carro ao qual esse preço pertence.
    public int IdCarro { get; set; }

    // Nome ou modelo do carro.
    public string NomeCarro { get; set; } = string.Empty;

    // Data em que esse preço foi registrado ou atualizado.
    public DateOnly DataPreco { get; set; }

    // Valor da entrada do carro.
    public decimal Entrada { get; set; }

    // Quantidade ou descrição das parcelas do financiamento.
    // Exemplo: "48x de R$ 1.500,00".
    public string Parcelas { get; set; } = string.Empty;

    // Preço do carro para pagamento à vista.
    public decimal PrecoVista { get; set; }

    // Valor estimado do IPVA do carro.
    public decimal IpvaEstimado { get; set; }

    // Status atual do preço ou da oferta.
    // Exemplo: "Ativo", "Inativo" ou "Promoção".
    public string Status { get; set; } = string.Empty;
}