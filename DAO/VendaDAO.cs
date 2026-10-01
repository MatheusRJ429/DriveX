// Importa a classe Conexao, responsável por abrir a conexão com o MySQL.
using DriveX.Configs;

// Importa a classe Venda, que representa os dados de uma venda.
using DriveX.Model;

namespace DriveX.DAO;

// Classe responsável por buscar e cadastrar vendas no banco.
public class VendaDAO
{
    // Guarda a conexão com o banco de dados.
    private readonly Conexao _conexao;

    // Recebe a conexão criada no Program.cs.
    public VendaDAO(Conexao conexao)
    {
        // Salva a conexão recebida.
        _conexao = conexao;
    }

    // Busca todas as vendas cadastradas.
    public List<Venda> Listar()
    {
        // Cria uma lista vazia para guardar as vendas.
        var lista = new List<Venda>();

        // Abre a conexão com o MySQL.
        using var con = _conexao.GetConnection();

        // Cria o comando SQL.
        using var comando = con.CreateCommand();

        // Busca as vendas, o nome do cliente e o nome do carro.
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

        // Executa a consulta.
        using var leitor = comando.ExecuteReader();

        // Percorre todas as vendas encontradas.
        while (leitor.Read())
        {
            // Cria um objeto Venda com os dados da linha atual.
            lista.Add(new Venda
            {
                // Pega o ID da venda.
                Id = Convert.ToInt32(leitor["id_venda"]),

                // Pega o ID do cliente.
                IdCliente = Convert.ToInt32(leitor["id_cliente_fk"]),

                // Pega o ID do carro.
                IdCarro = Convert.ToInt32(leitor["id_carro_fk"]),

                // Pega o nome do cliente.
                NomeCliente = leitor["nome_cliente"].ToString() ?? "",

                // Pega marca e modelo do carro.
                NomeCarro = leitor["nome_carro"].ToString() ?? "",

                // Converte a data da venda para DateOnly.
                DataVenda = DateOnly.FromDateTime(
                    Convert.ToDateTime(leitor["data_venda"])
                ),

                // Pega o valor da venda.
                ValorVenda = Convert.ToDecimal(leitor["valor_venda"]),

                // Pega a forma de pagamento.
                FormaPagamento = leitor["forma_pagamento"].ToString() ?? "",

                // Pega o status da venda.
                StatusVenda = leitor["status_venda"].ToString() ?? ""
            });
        }

        // Devolve a lista para a página Vendas.razor.
        return lista;
    }

    // Cadastra uma nova venda no banco.
    public void Adicionar(Venda venda)
    {
        // Abre a conexão com o MySQL.
        using var con = _conexao.GetConnection();

        // Cria o comando para inserir a venda.
        using var comandoVenda = con.CreateCommand();

        // INSERT que salva a venda na tabela Vendas.
        comandoVenda.CommandText = @"
            INSERT INTO Vendas
            (id_cliente_fk, id_carro_fk, data_venda, valor_venda, forma_pagamento, status_venda)
            VALUES
            (@idCliente, @idCarro, @dataVenda, @valorVenda, @formaPagamento, @statusVenda)";

        // Envia o ID do cliente selecionado.
        comandoVenda.Parameters.AddWithValue("@idCliente", venda.IdCliente);

        // Envia o ID do carro selecionado.
        comandoVenda.Parameters.AddWithValue("@idCarro", venda.IdCarro);

        // Converte DateOnly para DateTime antes de enviar ao MySQL.
        comandoVenda.Parameters.AddWithValue(
            "@dataVenda",
            venda.DataVenda.ToDateTime(TimeOnly.MinValue)
        );

        // Envia o valor da venda.
        comandoVenda.Parameters.AddWithValue("@valorVenda", venda.ValorVenda);

        // Envia a forma de pagamento.
        comandoVenda.Parameters.AddWithValue("@formaPagamento", venda.FormaPagamento);

        // Envia o status da venda.
        comandoVenda.Parameters.AddWithValue("@statusVenda", venda.StatusVenda);

        // Executa o INSERT e salva a venda.
        comandoVenda.ExecuteNonQuery();

        // Cria o comando para atualizar o status do carro.
        using var comandoCarro = con.CreateCommand();

        // Depois da venda, muda o status do veículo para vendido.
        comandoCarro.CommandText = @"
            UPDATE Carros
            SET status = 'vendido'
            WHERE id_carro = @idCarro";

        // Envia o ID do carro vendido.
        comandoCarro.Parameters.AddWithValue("@idCarro", venda.IdCarro);

        // Executa o UPDATE na tabela Carros.
        comandoCarro.ExecuteNonQuery();

        // Cria o comando para atualizar o status na tabela Precos.
        using var comandoPreco = con.CreateCommand();

        // Atualiza o status do preço para vendido também.
        comandoPreco.CommandText = @"
            UPDATE Precos
            SET status = 'vendido'
            WHERE id_carro_fk = @idCarro";

        // Envia o ID do carro vendido.
        comandoPreco.Parameters.AddWithValue("@idCarro", venda.IdCarro);

        // Executa o UPDATE na tabela Precos.
        comandoPreco.ExecuteNonQuery();
    }
}