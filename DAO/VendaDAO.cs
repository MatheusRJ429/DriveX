// Importa a classe Conexao, responsável por abrir a conexão com o MySQL.
using DriveX.Configs;

// Importa a classe Venda, que representa os dados de uma venda.
using DriveX.Model;

// Define o namespace onde ficam as classes que acessam o banco de dados.
namespace DriveX.DAO;

// Classe responsável por buscar as vendas cadastradas no banco.
public class VendaDAO
{
    // Guarda a conexão com o banco de dados.
    private readonly Conexao _conexao;

    // Construtor da classe.
    // Recebe a conexão criada e registrada no Program.cs.
    public VendaDAO(Conexao conexao)
    {
        // Salva a conexão recebida na variável _conexao.
        _conexao = conexao;
    }

    // Método que busca todas as vendas cadastradas.
    // Retorna uma lista de objetos Venda.
    public List<Venda> Listar()
    {
        // Cria uma lista vazia para guardar as vendas encontradas.
        var lista = new List<Venda>();

        // Abre a conexão com o banco MySQL.
        // using fecha a conexão automaticamente ao terminar o método.
        using var con = _conexao.GetConnection();

        // Cria o comando SQL que será enviado ao banco.
        using var comando = con.CreateCommand();

        // SELECT que busca os dados da tabela Vendas.
        // INNER JOIN junta Vendas com Clientes para mostrar o nome do cliente.
        // INNER JOIN junta Vendas com Carros para mostrar marca e modelo do carro.
        // CONCAT junta marca e modelo em um único texto.
        comando.CommandText = @"
            SELECT
                v.id_venda,
                v.id_cliente_fk,
                v.id_carro_fk,
                cli.nome AS nome_cliente,
                CONCAT(car.marca, ' ', car.modelo) AS nome_carro,
                v.data_venda,
                v.valor_venda,
                v.forma_pagamento,
                v.status_venda
            FROM Vendas v
            INNER JOIN Clientes cli
                ON cli.id_cliente = v.id_cliente_fk
            INNER JOIN Carros car
                ON car.id_carro = v.id_carro_fk
            ORDER BY v.id_venda DESC;
        ";

        // Executa a consulta SELECT.
        // leitor permite percorrer os registros encontrados.
        using var leitor = comando.ExecuteReader();

        // Enquanto houver registros no resultado da consulta...
        while (leitor.Read())
        {
            // Cria um objeto Venda para cada linha encontrada
            // e adiciona diretamente na lista.
            lista.Add(new Venda
            {
                // Pega o ID da venda.
                Id = Convert.ToInt32(leitor["id_venda"]),

                // Pega o ID do cliente que realizou a compra.
                IdCliente = Convert.ToInt32(leitor["id_cliente_fk"]),

                // Pega o ID do carro vendido.
                IdCarro = Convert.ToInt32(leitor["id_carro_fk"]),

                // Pega o nome do cliente pela tabela Clientes.
                NomeCliente = leitor["nome_cliente"].ToString() ?? "",

                // Pega a marca e o modelo do carro pela tabela Carros.
                NomeCarro = leitor["nome_carro"].ToString() ?? "",

                // Converte a data da venda vinda do MySQL para o tipo DateOnly.
                DataVenda = DateOnly.FromDateTime(
                    Convert.ToDateTime(leitor["data_venda"])
                ),

                // Pega o valor total da venda.
                ValorVenda = Convert.ToDecimal(leitor["valor_venda"]),

                // Pega a forma de pagamento: à vista, financiamento etc.
                FormaPagamento = leitor["forma_pagamento"].ToString() ?? "",

                // Pega o status da venda: concluída, em andamento etc.
                StatusVenda = leitor["status_venda"].ToString() ?? ""
            });
        }

        // Devolve a lista de vendas para a página Vendas.razor.
        return lista;
    }
}