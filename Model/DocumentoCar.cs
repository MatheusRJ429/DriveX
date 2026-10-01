
namespace DriveX.Model
{
   
    public class DocumentoCar
    {
        // ID único do documento.
        public int Id { get; set; }

        // Armazena o nome do documento.
        // Exemplo: "CRLV", "CNH", "Documento do veículo" etc.
        public string NomeDocumento { get; set; } = string.Empty;
    }
}