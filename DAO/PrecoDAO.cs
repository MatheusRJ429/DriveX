using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO;

public class PrecoDAO
{
    private readonly Conexao _conexao;

    public PrecoDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<Preco> Listar()
    {
        var lista = new List<Preco>();

        using var con = _conexao.GetConnection();
        using var comando = con.CreateCommand();

        comando.CommandText = "SELECT * FROM Precos";

        using var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            lista.Add(new Preco
            {
                Id = Convert.ToInt32(leitor["id_preco"]),
                IdCarro = Convert.ToInt32(leitor["id_carro_fk"]),
                DataPreco = DateOnly.FromDateTime(Convert.ToDateTime(leitor["data_preco"])),
                Entrada = Convert.ToDecimal(leitor["entrada"]),
                Parcelas = leitor["parcelas"].ToString() ?? "",
                PrecoVista = Convert.ToDecimal(leitor["preco_vista"]),
                IpvaEstimado = Convert.ToDecimal(leitor["ipva_estimado"]),
                Status = leitor["status"].ToString() ?? ""
            });
        }

        return lista;
    }
}