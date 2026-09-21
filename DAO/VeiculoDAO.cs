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
        try
        {
            var lista = new List<Veiculo>();

            using var con = _conexao.GetConnection();

            string sql = @"
                SELECT
                    id_carro AS id_vei,
                    modelo AS modelo_vei,
                    marca AS marca_vei,
                    'Não informada' AS placa_vei,
                    ano AS ano_vei,
                    'Automóvel' AS categoria_vei,
                    CASE
                        WHEN status = 'disponivel' THEN 'Disponível'
                        WHEN status = 'vendido' THEN 'Vendido'
                        ELSE status
                    END AS status_vei
                FROM Carros;
            ";

            using var comando = con.CreateCommand();
            comando.CommandText = sql;

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var veiculo = new Veiculo
                {
                    Id = Convert.ToInt32(leitor["id_vei"]),
                    Modelo = leitor.GetString("modelo_vei"),
                    Marca = leitor.GetString("marca_vei"),
                    Placa = leitor.GetString("placa_vei"),
                    Ano = Convert.ToInt32(leitor["ano_vei"]),
                    Categoria = leitor.GetString("categoria_vei"),
                    Status = leitor.GetString("status_vei")
                };

                lista.Add(veiculo);
            }

            return lista;
        }
        catch
        {
            throw;
        }
    }
}