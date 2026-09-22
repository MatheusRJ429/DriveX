using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO;

public class VendaDAO
{
    private readonly Conexao _conexao;

    public VendaDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<Venda> Listar()
    {
        var lista = new List<Venda>();

        using var con = _conexao.GetConnection();
        using var comando = con.CreateCommand();

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

        using var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            lista.Add(new Venda
            {
                Id = Convert.ToInt32(leitor["id_venda"]),
                IdCliente = Convert.ToInt32(leitor["id_cliente_fk"]),
                IdCarro = Convert.ToInt32(leitor["id_carro_fk"]),
                NomeCliente = leitor["nome_cliente"].ToString() ?? "",
                NomeCarro = leitor["nome_carro"].ToString() ?? "",
                DataVenda = DateOnly.FromDateTime(Convert.ToDateTime(leitor["data_venda"])),
                ValorVenda = Convert.ToDecimal(leitor["valor_venda"]),
                FormaPagamento = leitor["forma_pagamento"].ToString() ?? "",
                StatusVenda = leitor["status_venda"].ToString() ?? ""
            });
        }

        return lista;
    }
}