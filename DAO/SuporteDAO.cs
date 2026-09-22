using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO;

public class ChamadoSuporteDAO
{
    private readonly Conexao _conexao;

    public ChamadoSuporteDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<ChamadoSuporte> Listar()
    {
        var lista = new List<ChamadoSuporte>();

        using var con = _conexao.GetConnection();
        using var comando = con.CreateCommand();

        comando.CommandText = @"
            SELECT
                ch.id_chamado,
                cli.nome AS nome_cliente,
                ch.tipo_suporte,
                ch.mensagem,
                ch.data_chamado,
                ch.status
            FROM Chamados_Suporte ch
            INNER JOIN Clientes cli ON cli.id_cliente = ch.id_cliente_fk
            ORDER BY ch.data_chamado DESC;
        ";

        using var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            lista.Add(new ChamadoSuporte
            {
                Id = Convert.ToInt32(leitor["id_chamado"]),
                NomeCliente = leitor["nome_cliente"].ToString() ?? "",
                TipoSuporte = leitor["tipo_suporte"].ToString() ?? "",
                Mensagem = leitor["mensagem"].ToString() ?? "",
                DataChamado = leitor["data_chamado"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(leitor["data_chamado"]),
                Status = leitor["status"].ToString() ?? ""
            });
        }

        return lista;
    }
}