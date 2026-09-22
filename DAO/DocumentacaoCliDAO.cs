using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO;

public class DocumentacaoCliDAO
{
    private readonly Conexao _conexao;

    public DocumentacaoCliDAO(Conexao conexao)
    {
        _conexao = conexao;
    }

    public List<DocumentacaoCli> Listar()
    {
        var lista = new List<DocumentacaoCli>();

        using var con = _conexao.GetConnection();
        using var comando = con.CreateCommand();

        comando.CommandText = @"
            SELECT
                dc.id_documentacao,
                dc.id_cliente_fk,
                dc.id_documento_fk,
                cli.nome AS nome_cliente,
                doc.nome_documento,
                dc.conferido,
                dc.data_conferencia
            FROM Documentacao_Cli dc
            INNER JOIN Clientes cli
                ON cli.id_cliente = dc.id_cliente_fk
            INNER JOIN Documento_Car doc
                ON doc.id_documento = dc.id_documento_fk
            ORDER BY dc.id_documentacao DESC;
        ";

        using var leitor = comando.ExecuteReader();

        while (leitor.Read())
        {
            lista.Add(new DocumentacaoCli
            {
                Id = Convert.ToInt32(leitor["id_documentacao"]),
                IdCliente = Convert.ToInt32(leitor["id_cliente_fk"]),
                IdDocumento = Convert.ToInt32(leitor["id_documento_fk"]),
                NomeCliente = leitor["nome_cliente"].ToString() ?? "",
                NomeDocumento = leitor["nome_documento"].ToString() ?? "",
                Conferido = leitor["conferido"].ToString() ?? "",
                DataConferencia = leitor["data_conferencia"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(leitor["data_conferencia"])
            });
        }

        return lista;
    }
}