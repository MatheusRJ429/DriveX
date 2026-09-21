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

        comando.CommandText = "SELECT * FROM Vendas";

        using var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            lista.Add(new Venda
            {
                Id = Convert.ToInt32(leitor["id_venda"]),
                IdCliente = Convert.ToInt32(leitor["id_cliente_fk"]),
                IdCarro = Convert.ToInt32(leitor["id_carro_fk"]),
                DataVenda = DateOnly.FromDateTime(Convert.ToDateTime(leitor["data_venda"])),
                ValorVenda = Convert.ToDecimal(leitor["valor_venda"]),
                FormaPagamento = leitor["forma_pagamento"].ToString() ?? "",
                StatusVenda = leitor["status_venda"].ToString() ?? ""
            });
        }

        return lista;
    }
}