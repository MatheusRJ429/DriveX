namespace DriveX.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ModeloInteresse { get; set; } = string.Empty;
        public string StatusAtendimento { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
    }
}
