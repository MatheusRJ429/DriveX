namespace DriveX.Model
{
    public class ChamadoSuporte
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string TipoSuporte { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DateTime? DataChamado { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
