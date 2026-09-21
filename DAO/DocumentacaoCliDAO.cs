using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO
{
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

            comando.CommandText = "SELECT * FROM Documentacao_Cli";

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(new DocumentacaoCli
                {
                    Id = Convert.ToInt32(leitor["id_documentacao"]),
                    IdCliente = Convert.ToInt32(leitor["id_cliente_fk"]),
                    IdDocumento = Convert.ToInt32(leitor["id_documento_fk"]),
                    Conferido = leitor["conferido"].ToString() ?? "",
                    DataConferencia = leitor["data_conferencia"] == DBNull.Value
                        ? null
                        : Convert.ToDateTime(leitor["data_conferencia"])
                });
            }

            return lista;
        }
    }
}
