
namespace DriveX.Model;
public class DocumentacaoCli
{
    // ID único do registro da documentação.
    public int Id { get; set; }

    // ID do cliente ao qual essa documentação pertence.
    public int IdCliente { get; set; }

    // ID do documento relacionado ao cliente.
    public int IdDocumento { get; set; }

    // Nome do cliente.
    public string NomeCliente { get; set; } = string.Empty;

    // Nome do documento, por exemplo: RG, CPF ou CNH.
    public string NomeDocumento { get; set; } = string.Empty;

    // Indica se o documento já foi conferido.
    // Pode armazenar valores como "Sim" ou "Não".
    public string Conferido { get; set; } = string.Empty;

    // Armazena a data em que o documento foi conferido.
    // O ? permite que esse valor fique vazio (null) caso ainda não tenha sido conferido.
    public DateTime? DataConferencia { get; set; }
}