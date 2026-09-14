using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO;

public class VeiculoDAO
{
    private readonly Conexao _conexao;
    public VeiculoDAO(Conexao conexao) => _conexao = conexao;

    public List<Veiculo> Listar()
    {
        try
        {
            var lista = new List<Veiculo>();
            using var con = _conexao.GetConnection();
            using var comando = con.CreateCommand();
            comando.CommandText = "SELECT * FROM veiculos";
            using var leitor = comando.ExecuteReader();
            while (leitor.Read())
            {
                lista.Add(new Veiculo
                {
                    Id = Convert.ToInt32(leitor["id_vei"]),
                    Modelo = leitor.GetString("modelo_vei"),
                    Marca = leitor.GetString("marca_vei"),
                    Placa = leitor.GetString("placa_vei"),
                    Ano = Convert.ToInt32(leitor["ano_vei"]),
                    Categoria = leitor.GetString("categoria_vei"),
                    Status = leitor.GetString("status_vei")
                });
            }
            return lista;
        }
        catch { throw; }
    }
}
