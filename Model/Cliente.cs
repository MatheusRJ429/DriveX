namespace DriveX.Model
{
    // Representa um cliente da tabela Clientes.
    public class Cliente
    {
        // ID único do cliente.
        public int Id { get; set; }

        // Nome completo.
        public string Nome { get; set; } = string.Empty;

        // CPF do cliente.
        public string Cpf { get; set; } = string.Empty;

        // Telefone para contato.
        public string Telefone { get; set; } = string.Empty;

        // E-mail do cliente.
        public string Email { get; set; } = string.Empty;

        // Carro que o cliente demonstrou interesse.
        public string ModeloInteresse { get; set; } = string.Empty;

        // Status do atendimento: novo, em atendimento, concluido etc.
        public string StatusAtendimento { get; set; } = string.Empty;

        // Observações sobre o cliente.
        public string Observacao { get; set; } = string.Empty;
    }
}