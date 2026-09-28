using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO
{
    // Classe responsável por fazer as consultas e inserts de veículos no MySQL.
    public class VeiculoDAO
    {
        // Guarda a conexão com o banco.
        private readonly Conexao _conexao;

        // Recebe a conexão criada no Program.cs.
        public VeiculoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // Busca todos os veículos cadastrados no banco.
        public List<Veiculo> Listar()
        {
            // Lista que será devolvida para a página Veiculos.razor.
            var lista = new List<Veiculo>();

            try
            {
                // Abre conexão com o MySQL.
                using var con = _conexao.GetConnection();

                // SELECT para buscar os carros.
                string sql = @"
                    SELECT id_carro, marca, modelo, placa, ano, categoria,
                           cor, quilometragem, preco_vista, entrada,
                           parcelas, status
                    FROM Carros
                    ORDER BY id_carro DESC";

                // Cria o comando SQL.
                using var comando = con.CreateCommand();
                comando.CommandText = sql;

                // Executa o SELECT.
                using var leitor = comando.ExecuteReader();

                // Enquanto houver linhas no resultado...
                while (leitor.Read())
                {
                    // Cria um objeto Veiculo para cada carro do banco.
                    var veiculo = new Veiculo();

                    // Liga cada coluna do banco a uma propriedade do model.
                    veiculo.Id = Convert.ToInt32(leitor["id_carro"]);
                    veiculo.Marca = leitor["marca"].ToString() ?? "";
                    veiculo.Modelo = leitor["modelo"].ToString() ?? "";
                    veiculo.Placa = leitor["placa"].ToString() ?? "";
                    veiculo.Ano = Convert.ToInt32(leitor["ano"]);
                    veiculo.Categoria = leitor["categoria"].ToString() ?? "";
                    veiculo.Cor = leitor["cor"].ToString() ?? "";
                    veiculo.Quilometragem = Convert.ToInt32(leitor["quilometragem"]);
                    veiculo.PrecoVista = Convert.ToDecimal(leitor["preco_vista"]);
                    veiculo.Entrada = Convert.ToDecimal(leitor["entrada"]);
                    veiculo.Parcelas = leitor["parcelas"].ToString() ?? "";
                    veiculo.Status = leitor["status"].ToString() ?? "";

                    // Adiciona o carro na lista.
                    lista.Add(veiculo);
                }

                // Retorna a lista completa.
                return lista;
            }
            catch
            {
                // Se der erro no banco, mostra o erro para facilitar encontrar o problema.
                throw;
            }
        }

        // Adiciona um novo veículo no banco.
        public void Adicionar(Veiculo veiculo)
        {
            try
            {
                // Abre conexão.
                using var con = _conexao.GetConnection();

                // Insere as informações na tabela Carros.
                string sqlCarro = @"
                    INSERT INTO Carros
                    (marca, modelo, placa, ano, categoria, cor, quilometragem,
                     preco_vista, entrada, parcelas, status)
                    VALUES
                    (@marca, @modelo, @placa, @ano, @categoria, @cor, @quilometragem,
                     @precoVista, @entrada, @parcelas, @status)";

                using var comandoCarro = con.CreateCommand();
                comandoCarro.CommandText = sqlCarro;

                // Envia os valores do formulário para o SQL.
                comandoCarro.Parameters.AddWithValue("@marca", veiculo.Marca);
                comandoCarro.Parameters.AddWithValue("@modelo", veiculo.Modelo);
                comandoCarro.Parameters.AddWithValue("@placa", veiculo.Placa);
                comandoCarro.Parameters.AddWithValue("@ano", veiculo.Ano);
                comandoCarro.Parameters.AddWithValue("@categoria", veiculo.Categoria);
                comandoCarro.Parameters.AddWithValue("@cor", veiculo.Cor);
                comandoCarro.Parameters.AddWithValue("@quilometragem", veiculo.Quilometragem);
                comandoCarro.Parameters.AddWithValue("@precoVista", veiculo.PrecoVista);
                comandoCarro.Parameters.AddWithValue("@entrada", veiculo.Entrada);
                comandoCarro.Parameters.AddWithValue("@parcelas", veiculo.Parcelas);
                comandoCarro.Parameters.AddWithValue("@status", veiculo.Status);

                // Executa o INSERT.
                comandoCarro.ExecuteNonQuery();

                // Pega o ID do carro que acabou de ser cadastrado.
                int idCarro = Convert.ToInt32(comandoCarro.LastInsertedId);

                // Cria também um registro na tabela Precos.
                string sqlPreco = @"
                    INSERT INTO Precos
                    (id_carro_fk, data_preco, entrada, parcelas, preco_vista, ipva_estimado, status)
                    VALUES
                    (@idCarro, CURDATE(), @entrada, @parcelas, @precoVista, 0, @status)";

                using var comandoPreco = con.CreateCommand();
                comandoPreco.CommandText = sqlPreco;

                comandoPreco.Parameters.AddWithValue("@idCarro", idCarro);
                comandoPreco.Parameters.AddWithValue("@entrada", veiculo.Entrada);
                comandoPreco.Parameters.AddWithValue("@parcelas", veiculo.Parcelas);
                comandoPreco.Parameters.AddWithValue("@precoVista", veiculo.PrecoVista);
                comandoPreco.Parameters.AddWithValue("@status", veiculo.Status);

                // Executa o INSERT na tabela Precos.
                comandoPreco.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }
    }
}