// Importa a classe Conexao, responsável por abrir a conexão com o MySQL.
using DriveX.Configs;

// Importa a classe Veiculo, que representa os dados de um carro.
using DriveX.Model;

namespace DriveX.DAO
{
    // Classe responsável por consultar e cadastrar veículos no banco de dados.
    public class VeiculoDAO
    {
        // Guarda a conexão com o banco.
        // readonly significa que ela só pode receber valor no construtor.
        private readonly Conexao _conexao;

        // Construtor da classe.
        // Recebe a conexão criada e registrada no Program.cs.
        public VeiculoDAO(Conexao conexao)
        {
            // Salva a conexão recebida na variável _conexao.
            _conexao = conexao;
        }

        // Método que busca todos os veículos cadastrados.
        // Retorna uma lista de objetos Veiculo.
        public List<Veiculo> Listar()
        {
            // Cria uma lista vazia para guardar os veículos encontrados.
            var lista = new List<Veiculo>();

            try
            {
                // Abre a conexão com o banco MySQL.
                // using fecha a conexão automaticamente ao terminar o método.
                using var con = _conexao.GetConnection();

                // Consulta SQL que busca todos os dados dos veículos.
                // ORDER BY id_carro DESC mostra os carros mais recentes primeiro.
                string sql = @"
                    SELECT id_carro, marca, modelo, placa, ano, categoria,
                           cor, quilometragem, preco_vista, entrada,
                           parcelas, status
                    FROM Carros
                    ORDER BY id_carro DESC";

                // Cria o comando SQL usando a conexão aberta.
                using var comando = con.CreateCommand();

                // Define a consulta SQL que será executada.
                comando.CommandText = sql;

                // Executa o SELECT e guarda o resultado em leitor.
                using var leitor = comando.ExecuteReader();

                // Enquanto houver linhas no resultado da consulta...
                while (leitor.Read())
                {
                    // Cria um objeto Veiculo para cada carro encontrado.
                    var veiculo = new Veiculo();

                    // Pega o ID do veículo na tabela Carros.
                    veiculo.Id = Convert.ToInt32(leitor["id_carro"]);

                    // Pega a marca do veículo.
                    veiculo.Marca = leitor["marca"].ToString() ?? "";

                    // Pega o modelo do veículo.
                    veiculo.Modelo = leitor["modelo"].ToString() ?? "";

                    // Pega a placa do veículo.
                    veiculo.Placa = leitor["placa"].ToString() ?? "";

                    // Pega o ano do veículo.
                    veiculo.Ano = Convert.ToInt32(leitor["ano"]);

                    // Pega a categoria: SUV, Sedan, Hatch etc.
                    veiculo.Categoria = leitor["categoria"].ToString() ?? "";

                    // Pega a cor do veículo.
                    veiculo.Cor = leitor["cor"].ToString() ?? "";

                    // Pega a quilometragem.
                    veiculo.Quilometragem = Convert.ToInt32(leitor["quilometragem"]);

                    // Pega o preço à vista.
                    veiculo.PrecoVista = Convert.ToDecimal(leitor["preco_vista"]);

                    // Pega o valor da entrada.
                    veiculo.Entrada = Convert.ToDecimal(leitor["entrada"]);

                    // Pega as informações das parcelas.
                    veiculo.Parcelas = leitor["parcelas"].ToString() ?? "";

                    // Pega o status: disponivel, vendido ou manutencao.
                    veiculo.Status = leitor["status"].ToString() ?? "";

                    // Adiciona o veículo preenchido na lista.
                    lista.Add(veiculo);
                }

                // Devolve a lista para a página Veiculos.razor.
                return lista;
            }
            catch
            {
                // Se ocorrer erro de conexão ou SQL, repassa o erro para o sistema.
                throw;
            }
        }

        // Método que cadastra um novo veículo no banco.
        // Recebe um objeto Veiculo preenchido pelo formulário.
        public void Adicionar(Veiculo veiculo)
        {
            try
            {
                // Abre a conexão com o banco.
                using var con = _conexao.GetConnection();

                // Comando SQL que insere um novo carro na tabela Carros.
                // Os valores com @ serão preenchidos abaixo.
                string sqlCarro = @"
                    INSERT INTO Carros
                    (marca, modelo, placa, ano, categoria, cor, quilometragem,
                     preco_vista, entrada, parcelas, status)
                    VALUES
                    (@marca, @modelo, @placa, @ano, @categoria, @cor, @quilometragem,
                     @precoVista, @entrada, @parcelas, @status)";

                // Cria o comando para cadastrar o carro.
                using var comandoCarro = con.CreateCommand();

                // Define o INSERT que será executado.
                comandoCarro.CommandText = sqlCarro;

                // Envia a marca para o parâmetro @marca.
                comandoCarro.Parameters.AddWithValue("@marca", veiculo.Marca);

                // Envia o modelo para o parâmetro @modelo.
                comandoCarro.Parameters.AddWithValue("@modelo", veiculo.Modelo);

                // Envia a placa para o parâmetro @placa.
                comandoCarro.Parameters.AddWithValue("@placa", veiculo.Placa);

                // Envia o ano para o parâmetro @ano.
                comandoCarro.Parameters.AddWithValue("@ano", veiculo.Ano);

                // Envia a categoria para o parâmetro @categoria.
                comandoCarro.Parameters.AddWithValue("@categoria", veiculo.Categoria);

                // Envia a cor para o parâmetro @cor.
                comandoCarro.Parameters.AddWithValue("@cor", veiculo.Cor);

                // Envia a quilometragem para o parâmetro @quilometragem.
                comandoCarro.Parameters.AddWithValue("@quilometragem", veiculo.Quilometragem);

                // Envia o preço à vista para o parâmetro @precoVista.
                comandoCarro.Parameters.AddWithValue("@precoVista", veiculo.PrecoVista);

                // Envia o valor da entrada para o parâmetro @entrada.
                comandoCarro.Parameters.AddWithValue("@entrada", veiculo.Entrada);

                // Envia as parcelas para o parâmetro @parcelas.
                comandoCarro.Parameters.AddWithValue("@parcelas", veiculo.Parcelas);

                // Envia o status para o parâmetro @status.
                comandoCarro.Parameters.AddWithValue("@status", veiculo.Status);

                // Executa o INSERT e salva o veículo na tabela Carros.
                comandoCarro.ExecuteNonQuery();

                // Pega o ID do veículo que acabou de ser cadastrado.
                // Esse ID será usado para criar o preço ligado ao carro.
                int idCarro = Convert.ToInt32(comandoCarro.LastInsertedId);

                // Comando SQL que cria o preço inicial do novo veículo.
                // CURDATE() salva automaticamente a data atual.
                // O IPVA inicia com valor 0.
                string sqlPreco = @"
                    INSERT INTO Precos
                    (id_carro_fk, data_preco, entrada, parcelas, preco_vista, ipva_estimado, status)
                    VALUES
                    (@idCarro, CURDATE(), @entrada, @parcelas, @precoVista, 0, @status)";

                // Cria o comando para inserir o preço.
                using var comandoPreco = con.CreateCommand();

                // Define o INSERT da tabela Precos.
                comandoPreco.CommandText = sqlPreco;

                // Envia o ID do carro recém-cadastrado.
                comandoPreco.Parameters.AddWithValue("@idCarro", idCarro);

                // Envia o valor da entrada.
                comandoPreco.Parameters.AddWithValue("@entrada", veiculo.Entrada);

                // Envia as parcelas.
                comandoPreco.Parameters.AddWithValue("@parcelas", veiculo.Parcelas);

                // Envia o preço à vista.
                comandoPreco.Parameters.AddWithValue("@precoVista", veiculo.PrecoVista);

                // Envia o status do veículo.
                comandoPreco.Parameters.AddWithValue("@status", veiculo.Status);

                // Executa o INSERT e cria o preço ligado ao veículo.
                comandoPreco.ExecuteNonQuery();
            }
            catch
            {
                // Se ocorrer erro de conexão ou SQL, repassa o erro para o sistema.
                throw;
            }
        }
    }
}