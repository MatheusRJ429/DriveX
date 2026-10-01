// Importa a biblioteca do MySQL.
// Ela permite usar MySqlConnection e conectar o sistema ao banco.
using MySql.Data.MySqlClient;

namespace DriveX.Configs
{
    // Classe responsável por criar conexões com o banco de dados MySQL.
    public class Conexao
    {
        // Variável privada que guarda a string de conexão.
        // Ela contém servidor, porta, banco, usuário e senha.
        private readonly string _connectionString;

        // Construtor da classe Conexao.
        // IConfiguration lê as configurações do appsettings.json e do User Secrets.
        public Conexao(IConfiguration configuration)
        {
            // Busca a conexão chamada "MySqlConnection".
            // Se não encontrar uma conexão, usa uma string vazia para evitar valor nulo.
            _connectionString =
                configuration.GetConnectionString("MySqlConnection") ?? "";
        }

        // Método usado pelos DAOs para abrir uma conexão com o MySQL.
        public MySqlConnection GetConnection()
        {
            // Cria uma nova conexão usando a string salva em _connectionString.
            var conexao = new MySqlConnection(_connectionString);

            // Abre a conexão com o banco de dados.
            conexao.Open();

            // Devolve a conexão aberta para ser usada em SELECT, INSERT, UPDATE ou DELETE.
            return conexao;
        }
    }
}