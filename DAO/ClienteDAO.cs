using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO
{
    // Classe que conversa com a tabela Clientes.
    public class ClienteDAO
    {
        // Conexão com MySQL.
        private readonly Conexao _conexao;

        // Recebe a conexão pelo Program.cs.
        public ClienteDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // Busca todos os clientes.
        public List<Cliente> Listar()
        {
            var lista = new List<Cliente>();

            try
            {
                using var con = _conexao.GetConnection();

                string sql = @"
                    SELECT id_cliente, nome, cpf, telefone, email,
                           modelo_interesse, status_atend, observacao
                    FROM Clientes
                    ORDER BY id_cliente DESC";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    var cliente = new Cliente();

                    cliente.Id = Convert.ToInt32(leitor["id_cliente"]);
                    cliente.Nome = leitor["nome"].ToString() ?? "";
                    cliente.Cpf = leitor["cpf"].ToString() ?? "";
                    cliente.Telefone = leitor["telefone"].ToString() ?? "";
                    cliente.Email = leitor["email"].ToString() ?? "";
                    cliente.ModeloInteresse = leitor["modelo_interesse"].ToString() ?? "";
                    cliente.StatusAtendimento = leitor["status_atend"].ToString() ?? "";
                    cliente.Observacao = leitor["observacao"].ToString() ?? "";

                    lista.Add(cliente);
                }

                return lista;
            }
            catch
            {
                throw;
            }
        }

        // Cadastra um novo cliente.
        public void Adicionar(Cliente cliente)
        {
            try
            {
                using var con = _conexao.GetConnection();

                string sql = @"
                    INSERT INTO Clientes
                    (nome, cpf, telefone, email, modelo_interesse, status_atend, observacao)
                    VALUES
                    (@nome, @cpf, @telefone, @email, @modeloInteresse, @statusAtendimento, @observacao)";

                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@modeloInteresse", cliente.ModeloInteresse);
                comando.Parameters.AddWithValue("@statusAtendimento", cliente.StatusAtendimento);
                comando.Parameters.AddWithValue("@observacao", cliente.Observacao);

                // Executa o INSERT.
                comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}