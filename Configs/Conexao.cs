using MySql.Data.MySqlClient;

namespace DriveX.Configs
{
    public class Conexao
    {
        private readonly string _connectionString;

        public Conexao(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("MySqlConnection") ?? "";
        }

        public MySqlConnection GetConnection()
        {
            var conexao = new MySqlConnection(_connectionString);

            // Abre a conexão com o banco.
            conexao.Open();

            return conexao;
        }
    }
}