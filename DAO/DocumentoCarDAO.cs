using DriveX.Configs;
using DriveX.Model;

namespace DriveX.DAO
{
    public class DocumentoCarDAO
    {
        private readonly Conexao _conexao;

        public DocumentoCarDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        public List<DocumentoCar> Listar()
        {
            var lista = new List<DocumentoCar>();

            using var con = _conexao.GetConnection();
            using var comando = con.CreateCommand();

            comando.CommandText = "SELECT * FROM Documento_Car";

            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                lista.Add(new DocumentoCar
                {
                    Id = Convert.ToInt32(leitor["id_documento"]),
                    NomeDocumento = leitor["nome_documento"].ToString() ?? ""
                });
            }

            return lista;
        }
    }
}
