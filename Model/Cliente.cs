
namespace DriveX.Model
{
    public class Cliente
    {
        // Armazena o ID único do cliente.
        public int Id { get; set; }

        // Armazena o nome completo do cliente.
        // string.Empty define um valor inicial vazio.
        public string Nome { get; set; } = string.Empty;

        // Armazena o CPF do cliente.
        public string Cpf { get; set; } = string.Empty;

        // Armazena o telefone do cliente.
        public string Telefone { get; set; } = string.Empty;

        // Armazena o e-mail do cliente.
        public string Email { get; set; } = string.Empty;

        // Armazena o modelo do carro que o cliente demonstrou interesse.
        public string ModeloInteresse { get; set; } = string.Empty;

        // Armazena o status atual do atendimento.
        // Exemplos: "Novo", "Em atendimento" ou "Concluído".
        public string StatusAtendimento { get; set; } = string.Empty;

        // Armazena observações ou informações adicionais sobre o cliente.
        public string Observacao { get; set; } = string.Empty;
    }
}