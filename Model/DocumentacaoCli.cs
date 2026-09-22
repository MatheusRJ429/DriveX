namespace DriveX.Model;

public class DocumentacaoCli
{
    public int Id { get; set; }
    public int IdCliente { get; set; }
    public int IdDocumento { get; set; }
    public string NomeCliente { get; set; } = string.Empty;
    public string NomeDocumento { get; set; } = string.Empty;
    public string Conferido { get; set; } = string.Empty;
    public DateTime? DataConferencia { get; set; }
}