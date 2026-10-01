// Importa a classe Conexao, responsável por abrir a conexão com o MySQL.
using DriveX.Configs;

// Importa a classe Preco, que representa os preços dos veículos.
using DriveX.Model;

// Define o namespace onde ficam as classes que acessam o banco de dados.
namespace DriveX.DAO;

// Classe responsável por buscar os preços dos carros na tabela Precos.
public class PrecoDAO
{
    // Guarda a conexão com o banco de dados.
    private readonly Conexao _conexao;

    // Construtor da classe.
    // Recebe a conexão criada e registrada no Program.cs.
    public PrecoDAO(Conexao conexao)
    {
        // Salva a conexão recebida na variável _conexao.
        _conexao = conexao;
    }

    // Método que busca todos os preços cadastrados no banco.
    // Retorna uma lista de objetos Preco.
    public List<Preco> Listar()
    {
        // Cria uma lista vazia para guardar os preços encontrados.
        var lista = new List<Preco>();

        // Abre a conexão com o MySQL.
        // using fecha a conexão automaticamente ao terminar o método.
        using var con = _conexao.GetConnection();

        // Cria o comando SQL que será executado no banco.
        using var comando = con.CreateCommand();

        // SELECT que busca os preços e junta as tabelas Precos e Carros.
        // CONCAT junta a marca e o modelo para formar o nome completo do carro.
        // INNER JOIN permite mostrar o carro relacionado a cada preço.
        comando.CommandText = @"
            SELECT
                p.id_preco,
                p.id_carro_fk,
                CONCAT(c.marca, ' ', c.modelo) AS nome_carro,
                p.data_preco,
                p.entrada,
                p.parcelas,
                p.preco_vista,
                p.ipva_estimado,
                p.status
            FROM Precos p
            INNER JOIN Carros c
                ON c.id_carro = p.id_carro_fk
            ORDER BY p.id_preco DESC;
        ";

        // Executa a consulta SELECT.
        // leitor permite percorrer os registros encontrados.
        using var leitor = comando.ExecuteReader();

        // Enquanto houver registros no resultado da consulta...
        while (leitor.Read())
        {
            // Cria um objeto Preco para cada registro encontrado
            // e adiciona diretamente na lista.
            lista.Add(new Preco
            {
                // Pega o ID do preço.
                Id = Convert.ToInt32(leitor["id_preco"]),

                // Pega o ID do carro relacionado ao preço.
                IdCarro = Convert.ToInt32(leitor["id_carro_fk"]),

                // Pega o nome completo do carro criado pelo CONCAT no SQL.
                NomeCarro = leitor["nome_carro"].ToString() ?? "",

                // Converte a data que vem do MySQL para o tipo DateOnly.
                DataPreco = DateOnly.FromDateTime(
                    Convert.ToDateTime(leitor["data_preco"])
                ),

                // Pega o valor da entrada.
                Entrada = Convert.ToDecimal(leitor["entrada"]),

                // Pega a descrição das parcelas.
                Parcelas = leitor["parcelas"].ToString() ?? "",

                // Pega o preço total para pagamento à vista.
                PrecoVista = Convert.ToDecimal(leitor["preco_vista"]),

                // Pega o valor estimado do IPVA.
                IpvaEstimado = Convert.ToDecimal(leitor["ipva_estimado"]),

                // Pega o status do veículo: disponível, vendido ou manutenção.
                Status = leitor["status"].ToString() ?? ""
            });
        }

        // Devolve a lista de preços para a página Precos.razor.
        return lista;
    }
}