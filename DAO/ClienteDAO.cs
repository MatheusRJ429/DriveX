// Importa a classe Conexao, responsável por abrir a conexão com o MySQL.
using DriveX.Configs;

// Importa a classe Cliente, que representa os dados de um cliente.
using DriveX.Model;

namespace DriveX.DAO
{
    // Classe responsável por fazer consultas e cadastros na tabela Clientes.
    public class ClienteDAO
    {
        // Guarda a conexão com o banco de dados.
        // readonly significa que ela só pode receber valor no construtor.
        private readonly Conexao _conexao;

        // Construtor da classe.
        // Recebe a conexão criada e registrada no Program.cs.
        public ClienteDAO(Conexao conexao)
        {
            // Salva a conexão recebida na variável _conexao.
            _conexao = conexao;
        }

        // Método que busca todos os clientes cadastrados no banco.
        // Retorna uma lista de objetos Cliente.
        public List<Cliente> Listar()
        {
            // Cria uma lista vazia para guardar os clientes encontrados.
            var lista = new List<Cliente>();

            try
            {
                // Abre a conexão com o banco.
                // using fecha a conexão automaticamente ao terminar este bloco.
                using var con = _conexao.GetConnection();

                // Consulta SQL que busca as colunas da tabela Clientes.
                // ORDER BY id_cliente DESC mostra os clientes mais recentes primeiro.
                string sql = @"
                    SELECT id_cliente, nome, cpf, telefone, email,
                           modelo_interesse, status_atend, observacao
                    FROM Clientes
                    ORDER BY id_cliente DESC";

                // Cria um comando SQL usando a conexão aberta.
                using var comando = con.CreateCommand();

                // Define qual consulta SQL será executada.
                comando.CommandText = sql;

                // Executa o SELECT e guarda o resultado em leitor.
                using var leitor = comando.ExecuteReader();

                // Enquanto existirem linhas no resultado da consulta...
                while (leitor.Read())
                {
                    // Cria um novo objeto Cliente para cada linha encontrada.
                    var cliente = new Cliente();

                    // Pega o ID do cliente no banco e coloca na propriedade Id.
                    cliente.Id = Convert.ToInt32(leitor["id_cliente"]);

                    // Pega o nome do cliente.
                    // ?? "" evita erro caso a coluna venha vazia.
                    cliente.Nome = leitor["nome"].ToString() ?? "";

                    // Pega o CPF do cliente.
                    cliente.Cpf = leitor["cpf"].ToString() ?? "";

                    // Pega o telefone do cliente.
                    cliente.Telefone = leitor["telefone"].ToString() ?? "";

                    // Pega o e-mail do cliente.
                    cliente.Email = leitor["email"].ToString() ?? "";

                    // Pega o carro ou modelo de interesse do cliente.
                    cliente.ModeloInteresse = leitor["modelo_interesse"].ToString() ?? "";

                    // Pega o status do atendimento.
                    cliente.StatusAtendimento = leitor["status_atend"].ToString() ?? "";

                    // Pega observações adicionais sobre o cliente.
                    cliente.Observacao = leitor["observacao"].ToString() ?? "";

                    // Adiciona o cliente preenchido na lista.
                    lista.Add(cliente);
                }

                // Devolve a lista completa para a página Cliente.razor.
                return lista;
            }
            catch
            {
                // Se ocorrer um erro de conexão ou SQL,
                // repassa o erro para a página ou para o terminal mostrar.
                throw;
            }
        }

        // Método responsável por cadastrar um novo cliente no banco.
        // Recebe um objeto Cliente preenchido pelo formulário.
        public void Adicionar(Cliente cliente)
        {
            try
            {
                // Abre a conexão com o banco.
                using var con = _conexao.GetConnection();

                // Comando SQL para inserir um novo registro na tabela Clientes.
                // Os valores iniciados com @ serão preenchidos abaixo.
                string sql = @"
                    INSERT INTO Clientes
                    (nome, cpf, telefone, email, modelo_interesse, status_atend, observacao)
                    VALUES
                    (@nome, @cpf, @telefone, @email, @modeloInteresse, @statusAtendimento, @observacao)";

                // Cria o comando SQL.
                using var comando = con.CreateCommand();

                // Define o INSERT que será executado.
                comando.CommandText = sql;

                // Envia o nome digitado no formulário para o parâmetro @nome.
                comando.Parameters.AddWithValue("@nome", cliente.Nome);

                // Envia o CPF para o parâmetro @cpf.
                comando.Parameters.AddWithValue("@cpf", cliente.Cpf);

                // Envia o telefone para o parâmetro @telefone.
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);

                // Envia o e-mail para o parâmetro @email.
                comando.Parameters.AddWithValue("@email", cliente.Email);

                // Envia o modelo de interesse para o parâmetro @modeloInteresse.
                comando.Parameters.AddWithValue("@modeloInteresse", cliente.ModeloInteresse);

                // Envia o status do atendimento para o parâmetro @statusAtendimento.
                comando.Parameters.AddWithValue("@statusAtendimento", cliente.StatusAtendimento);

                // Envia a observação para o parâmetro @observacao.
                comando.Parameters.AddWithValue("@observacao", cliente.Observacao);

                // Executa o INSERT e salva o cliente no banco de dados.
                comando.ExecuteNonQuery();
            }
            catch
            {
                // Se acontecer algum erro, repassa o erro para o sistema mostrar.
                throw;
            }
        }
    }
}