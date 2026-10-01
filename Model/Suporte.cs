namespace DriveX.Model;

public class ChamadoSuporte
{
    // ID único do chamado.
    public int Id { get; set; }

    // ID do cliente que abriu o chamado.
    public int IdCliente { get; set; }

    // Nome do cliente que solicitou o suporte.
    public string NomeCliente { get; set; } = string.Empty;

    // Tipo ou categoria do suporte solicitado.
    // Exemplo: "Problema no veículo", "Dúvida" ou "Financiamento".
    public string TipoSuporte { get; set; } = string.Empty;

    // Mensagem ou descrição do problema informado pelo cliente.
    public string Mensagem { get; set; } = string.Empty;

    // Data e horário em que o chamado foi registrado.
    // O ? permite que a data fique vazia (null).
    public DateTime? DataChamado { get; set; }

    // Status atual do chamado.
    // Exemplo: "Aberto", "Em atendimento" ou "Concluído".
    public string Status { get; set; } = string.Empty;
}