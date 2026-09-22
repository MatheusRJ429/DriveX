using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO;

public class VeiculoDAO
{
    private readonly Conexao _conexao;

    public VeiculoDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<Veiculo> Listar()
    {
        var lista = new List<Veiculo>();

        using var con = _conexao.GetConnection();
        using var comando = con.CreateCommand();

        comando.CommandText = @"
            SELECT
                id_carro,
                marca,
                modelo,
                placa,
                ano,
                categoria,
                CASE
                    WHEN status = 'disponivel' THEN 'Disponível'
                    WHEN status = 'vendido' THEN 'Vendido'
                    WHEN status = 'manutencao' THEN 'Manutenção'
                    ELSE status
                END AS status_exibicao
            FROM Carros
            ORDER BY id_carro DESC;
        ";

        using var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            lista.Add(new Veiculo
            {
                Id = Convert.ToInt32(leitor["id_carro"]),
                Marca = leitor["marca"].ToString() ?? "",
                Modelo = leitor["modelo"].ToString() ?? "",
                Placa = leitor["placa"].ToString() ?? "",
                Ano = Convert.ToInt32(leitor["ano"]),
                Categoria = leitor["categoria"].ToString() ?? "",
                Status = leitor["status_exibicao"].ToString() ?? ""
            });
        }

        return lista;
    }
}